using Chr.Avro.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Chr.Avro.Resolution
{
    /// <summary>
    /// A type resolver that relies solely on <see cref="Type" /> methods. It’s configured with a
    /// reasonable set of cases that cover most common scenarios.
    /// </summary>
    public class ReflectionResolver : TypeResolver
    {
        /// <summary>
        /// Creates a new reflection resolver.
        /// </summary>
        public ReflectionResolver()
        {
            var additional = new ITypeResolverCase[]
            {
                // nullables:
                new NullableResolverCase(this),

                // primitives:
                new BooleanResolverCase(),
                new ByteResolverCase(),
                new ByteArrayResolverCase(),
                new DecimalResolverCase(),
                new DoubleResolverCase(),
                new SingleResolverCase(),
                new Int16ResolverCase(),
                new Int32ResolverCase(),
                new Int64ResolverCase(),
                new SByteResolverCase(),
                new StringResolverCase(),
                new UInt16ResolverCase(),
                new UInt32ResolverCase(),
                new UInt64ResolverCase(),

                // enums:
                new EnumResolverCase(),

                // dictionaries:
                new DictionaryResolverCase(),

                // enumerables:
                new EnumerableResolverCase(),

                // built-ins:
                new DateTimeResolverCase(),
                new GuidResolverCase(),
                new TimeSpanResolverCase(),
                new UriResolverCase(),

                // classes and structs:
                new ObjectResolverCase()
            };

            Cases = additional.Concat(Cases).ToList();
        }
    }

    /// <summary>
    /// An <see cref="ITypeResolverCase" /> that gets its information from type reflection.
    /// </summary>
    public abstract class ReflectionResolverCase : TypeResolverCase { }

    /// <summary>
    /// A type resolver case that matches <see cref="bool" />.
    /// </summary>
    public class BooleanResolverCase : ReflectionResolverCase
    {
        /// <summary>
        /// Determines whether the case can be applied to a type.
        /// </summary>
        /// <returns>
        /// Whether the type is <see cref="bool" />.
        /// </returns>
        public override bool IsMatch(Type type)
        {
            return type == typeof(bool);
        }

        /// <summary>
        /// Resolves boolean type information.
        /// </summary>
        /// <param name="type">
        /// The type to resolve.
        /// </param>
        /// <returns>
        /// A <see cref="BooleanResolution" /> with information about the type.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the type is not <see cref="bool" />.
        /// </exception>
        public override TypeResolution Resolve(Type type)
        {
            if (!IsMatch(type))
            {
                throw new ArgumentException($"The boolean case can only be applied to {typeof(bool).FullName}.", nameof(type));
            }

            return new BooleanResolution(type);
        }
    }

    /// <summary>
    /// A type resolver case that matches <see cref="byte" />.
    /// </summary>
    public class ByteResolverCase : ReflectionResolverCase
    {
        /// <summary>
        /// Determines whether the case can be applied to a type.
        /// </summary>
        /// <returns>
        /// Whether the type is <see cref="byte" />.
        /// </returns>
        public override bool IsMatch(Type type)
        {
            return type == typeof(byte);
        }

        /// <summary>
        /// Resolves byte (8-bit unsigned integer) type information.
        /// </summary>
        /// <param name="type">
        /// The type to resolve.
        /// </param>
        /// <returns>
        /// An <see cref="IntegerResolution" /> with information about the type.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the type is not <see cref="byte" />.
        /// </exception>
        public override TypeResolution Resolve(Type type)
        {
            if (!IsMatch(type))
            {
                throw new ArgumentException($"The byte case can only be applied to {typeof(byte).FullName}.", nameof(type));
            }

            return new IntegerResolution(type, false, 8);
        }
    }

    /// <summary>
    /// A type resolver case that matches <see cref="T:System.Byte[]" />.
    /// </summary>
    public class ByteArrayResolverCase : ReflectionResolverCase
    {
        /// <summary>
        /// Determines whether the case can be applied to a type.
        /// </summary>
        /// <returns>
        /// Whether the type is <see cref="T:System.Byte[]" />.
        /// </returns>
        public override bool IsMatch(Type type)
        {
            return type == typeof(byte[]);
        }

        /// <summary>
        /// Resolves byte array type information.
        /// </summary>
        /// <param name="type">
        /// The type to resolve.
        /// </param>
        /// <returns>
        /// A <see cref="ByteArrayResolution" /> with information about the type.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the type is not <see cref="T:System.Byte[]" />.
        /// </exception>
        public override TypeResolution Resolve(Type type)
        {
            if (!IsMatch(type))
            {
                throw new ArgumentException($"The byte array case can only be applied to {typeof(byte[]).FullName}.", nameof(type));
            }

            return new ByteArrayResolution(type);
        }
    }

    /// <summary>
    /// A type resolver case that matches <see cref="DateTime" /> and <see cref="DateTimeOffset" />.
    /// </summary>
    public class DateTimeResolverCase : ReflectionResolverCase
    {
        /// <summary>
        /// Determines whether the case can be applied to a type.
        /// </summary>
        /// <returns>
        /// Whether the type is <see cref="DateTime" /> or <see cref="DateTimeOffset" />.
        /// </returns>
        public override bool IsMatch(Type type)
        {
            return type == typeof(DateTime) || type == typeof(DateTimeOffset);
        }

        /// <summary>
        /// Resolves date/time type information.
        /// </summary>
        /// <param name="type">
        /// The type to resolve.
        /// </param>
        /// <returns>
        /// A <see cref="TimestampResolution" /> with information about the type.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the type is not <see cref="DateTime" /> or <see cref="DateTimeOffset" />.
        /// </exception>
        public override TypeResolution Resolve(Type type)
        {
            if (!IsMatch(type))
            {
                throw new ArgumentException($"The date/time case can only be applied to {typeof(DateTime).FullName} or {typeof(DateTimeOffset).FullName}.", nameof(type));
            }

            return new TimestampResolution(type, 1m / TimeSpan.TicksPerSecond);
        }
    }

    /// <summary>
    /// A type resolver case that matches <see cref="decimal" />.
    /// </summary>
    public class DecimalResolverCase : ReflectionResolverCase
    {
        /// <summary>
        /// Determines whether the case can be applied to a type.
        /// </summary>
        /// <returns>
        /// Whether the type is <see cref="decimal" />.
        /// </returns>
        public override bool IsMatch(Type type)
        {
            return type == typeof(decimal);
        }

        /// <summary>
        /// Resolves decimal type information.
        /// </summary>
        /// <param name="type">
        /// The type to resolve.
        /// </param>
        /// <returns>
        /// A <see cref="DecimalResolution" /> with information about the type.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the type is not <see cref="decimal" />.
        /// </exception>
        public override TypeResolution Resolve(Type type)
        {
            if (!IsMatch(type))
            {
                throw new ArgumentException($"The decimal case can only be applied to {typeof(decimal).FullName}.", nameof(type));
            }

            return new DecimalResolution(type, 29, 14);
        }
    }

    /// <summary>
    /// A type resolver case that matches <see cref="T:System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair`2}" />.
    /// </summary>
    public class DictionaryResolverCase : ReflectionResolverCase
    {
        /// <summary>
        /// Determines whether the case can be applied to a type.
        /// </summary>
        /// <returns>
        /// Whether the type is <see cref="T:System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair`2}" />.
        /// </returns>
        public override bool IsMatch(Type type)
        {
            return type.GetEnumerableType() is Type pair
                && pair.IsGenericType
                && pair.GetGenericTypeDefinition() == typeof(KeyValuePair<,>);
        }

        /// <summary>
        /// Resolves dictionary type information.
        /// </summary>
        /// <param name="type">
        /// The type to resolve.
        /// </param>
        /// <returns>
        /// A <see cref="MapResolution" /> with information about the type.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the type is not <see cref="T:System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair`2}" />.
        /// </exception>
        public override TypeResolution Resolve(Type type)
        {
            if (!IsMatch(type))
            {
                throw new ArgumentException($"The dictionary case can only be applied to {typeof(IEnumerable<>).MakeGenericType(typeof(KeyValuePair<,>)).FullName}.", nameof(type));
            }
            
            var parameters = type.GetEnumerableType().GetGenericArguments();
            var key = parameters.ElementAt(0);
            var value = parameters.ElementAt(1);

            return new MapResolution(type, key, value);
        }
    }

    /// <summary>
    /// A type resolver case that matches <see cref="double" />.
    /// </summary>
    public class DoubleResolverCase : ReflectionResolverCase
    {
        /// <summary>
        /// Determines whether the case can be applied to a type.
        /// </summary>
        /// <returns>
        /// Whether the type is <see cref="double" />.
        /// </returns>
        public override bool IsMatch(Type type)
        {
            return type == typeof(double);
        }

        /// <summary>
        /// Resolves double-precision floating-point type information.
        /// </summary>
        /// <param name="type">
        /// The type to resolve.
        /// </param>
        /// <returns>
        /// A <see cref="FloatingPointResolution" /> with information about the type.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the type is not <see cref="double" />.
        /// </exception>
        public override TypeResolution Resolve(Type type)
        {
            if (!IsMatch(type))
            {
                throw new ArgumentException($"The double case can only be applied to {typeof(double).FullName}.", nameof(type));
            }

            return new FloatingPointResolution(type, 16);
        }
    }

    /// <summary>
    /// A type resolver case that matches <see cref="Enum" /> types.
    /// </summary>
    public class EnumResolverCase : ReflectionResolverCase
    {
        /// <summary>
        /// Determines whether the case can be applied to a type.
        /// </summary>
        /// <returns>
        /// Whether the type is an enum type.
        /// </returns>
        public override bool IsMatch(Type type)
        {
            return type.IsEnum;
        }

        /// <summary>
        /// Resolves enum type information.
        /// </summary>
        /// <param name="type">
        /// The type to resolve.
        /// </param>
        /// <returns>
        /// An <see cref="EnumResolution" /> with information about the type.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the type is not an enum type.
        /// </exception>
        public override TypeResolution Resolve(Type type)
        {
            if (!IsMatch(type))
            {
                throw new ArgumentException("The enum case can only be applied to enum types.", nameof(type));
            }

            var name = new IdentifierResolution(type.Name);

            var @namespace = string.IsNullOrEmpty(type.Namespace)
                ? null
                : new IdentifierResolution(type.Namespace);

            var hasFlagsAttribute = type.GetCustomAttributes(typeof(FlagsAttribute), true)
                .Any();

            var symbols = type.GetFields(BindingFlags.Public | BindingFlags.Static)
                .Select(f =>
                {
                    // FieldInfo.GetRawConstantValue is arguably nicer than Enum.Parse, but it’s
                    // easier to sort and test the enum values than the underlying constants:
                    var value = Enum.Parse(type, f.Name);

                    return new SymbolResolution(f, new IdentifierResolution(f.Name), value);
                })
                .OrderBy(s => s.Value)
                .ThenBy(s => s.Name.Value)
                .ToList();

            return new EnumResolution(type, name, @namespace, hasFlagsAttribute, symbols);
        }
    }

    /// <summary>
    /// A type resolver case that matches <see cref="IEnumerable{T}" />.
    /// </summary>
    public class EnumerableResolverCase : ReflectionResolverCase
    {
        /// <summary>
        /// Determines whether the case can be applied to a type.
        /// </summary>
        /// <returns>
        /// Whether the type is <see cref="IEnumerable{T}" />.
        /// </returns>
        public override bool IsMatch(Type type)
        {
            return type.GetEnumerableType() != null;
        }

        /// <summary>
        /// Resolves enumerable type information.
        /// </summary>
        /// <param name="type">
        /// The type to resolve.
        /// </param>
        /// <returns>
        /// An <see cref="ArrayResolution" /> with information about the type.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the type is not <see cref="IEnumerable{T}" />.
        /// </exception>
        public override TypeResolution Resolve(Type type)
        {
            if (!IsMatch(type))
            {
                throw new ArgumentException($"The enumerable case can only be applied to {typeof(IEnumerable<>).FullName}.", nameof(type));
            }

            return new ArrayResolution(type, type.GetEnumerableType());
        }
    }

    /// <summary>
    /// A type resolver case that matches <see cref="Guid" />.
    /// </summary>
    public class GuidResolverCase : ReflectionResolverCase
    {
        /// <summary>
        /// Determines whether the case can be applied to a type.
        /// </summary>
        /// <returns>
        /// Whether the type is <see cref="Guid" />.
        /// </returns>
        public override bool IsMatch(Type type)
        {
            return type == typeof(Guid);
        }

        /// <summary>
        /// Resolves GUID type information.
        /// </summary>
        /// <param name="type">
        /// The type to resolve.
        /// </param>
        /// <returns>
        /// A <see cref="UuidResolution" /> with information about the type.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the type is not <see cref="Guid" />.
        /// </exception>
        public override TypeResolution Resolve(Type type)
        {
            if (!IsMatch(type))
            {
                throw new ArgumentException($"The GUID case can only be applied to {typeof(Guid).FullName}.", nameof(type));
            }

            return new UuidResolution(type, 2, 4);
        }
    }

    /// <summary>
    /// A type resolver case that matches <see cref="short" />.
    /// </summary>
    public class Int16ResolverCase : ReflectionResolverCase
    {
        /// <summary>
        /// Determines whether the case can be applied to a type.
        /// </summary>
        /// <returns>
        /// Whether the type is <see cref="short" />.
        /// </returns>
        public override bool IsMatch(Type type)
        {
            return type == typeof(short);
        }

        /// <summary>
        /// Resolves short (16-bit signed integer) type information.
        /// </summary>
        /// <param name="type">
        /// The type to resolve.
        /// </param>
        /// <returns>
        /// An <see cref="IntegerResolution" /> with information about the type.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the type is not <see cref="short" />.
        /// </exception>
        public override TypeResolution Resolve(Type type)
        {
            if (!IsMatch(type))
            {
                throw new ArgumentException($"The int16 case can only be applied to {typeof(short).FullName}.", nameof(type));
            }

            return new IntegerResolution(type, true, 16);
        }
    }

    /// <summary>
    /// A type resolver case that matches <see cref="int" />.
    /// </summary>
    public class Int32ResolverCase : ReflectionResolverCase
    {
        /// <summary>
        /// Determines whether the case can be applied to a type.
        /// </summary>
        /// <returns>
        /// Whether the type is <see cref="int" />.
        /// </returns>
        public override bool IsMatch(Type type)
        {
            return type == typeof(int);
        }

        /// <summary>
        /// Resolves int (32-bit signed integer) type information.
        /// </summary>
        /// <param name="type">
        /// The type to resolve.
        /// </param>
        /// <returns>
        /// An <see cref="IntegerResolution" /> with information about the type.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the type is not <see cref="int" />.
        /// </exception>
        public override TypeResolution Resolve(Type type)
        {
            if (!IsMatch(type))
            {
                throw new ArgumentException($"The int32 case can only be applied to {typeof(int).FullName}.", nameof(type));
            }

            return new IntegerResolution(type, true, 32);
        }
    }

    /// <summary>
    /// A type resolver case that matches <see cref="long" />.
    /// </summary>
    public class Int64ResolverCase : ReflectionResolverCase
    {
        /// <summary>
        /// Determines whether the case can be applied to a type.
        /// </summary>
        /// <returns>
        /// Whether the type is <see cref="long" />.
        /// </returns>
        public override bool IsMatch(Type type)
        {
            return type == typeof(long);
        }

        /// <summary>
        /// Resolves long (64-bit signed integer) type information.
        /// </summary>
        /// <param name="type">
        /// The type to resolve.
        /// </param>
        /// <returns>
        /// An <see cref="IntegerResolution" /> with information about the type.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the type is not <see cref="long" />.
        /// </exception>
        public override TypeResolution Resolve(Type type)
        {
            if (!IsMatch(type))
            {
                throw new ArgumentException($"The int64 case can only be applied to {typeof(long).FullName}.", nameof(type));
            }

            return new IntegerResolution(type, true, 64);
        }
    }

    /// <summary>
    /// A type resolver case that matches <see cref="Nullable{T}" />.
    /// </summary>
    public class NullableResolverCase : ReflectionResolverCase
    {
        /// <summary>
        /// The resolver instance to use to resolve underlying types.
        /// </summary>
        protected readonly ITypeResolver Resolver;
        
        /// <summary>
        /// Creates a new nullable resolver case.
        /// </summary>
        /// <param name="resolver">
        /// The resolver instance to use to resolve underlying types.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the resolver is null.
        /// </exception>
        public NullableResolverCase(ITypeResolver resolver)
        {
            Resolver = resolver ?? throw new ArgumentNullException(nameof(resolver), "Resolver cannot be null.");
        }

        /// <summary>
        /// Determines whether the case can be applied to a type.
        /// </summary>
        /// <returns>
        /// Whether the type is <see cref="Nullable{T}" />.
        /// </returns>
        public override bool IsMatch(Type type)
        {
            return Nullable.GetUnderlyingType(type) != null;
        }

        /// <summary>
        /// Resolves nullable type information.
        /// </summary>
        /// <param name="type">
        /// The type to resolve.
        /// </param>
        /// <returns>
        /// A <see cref="TypeResolution" /> for the underlying type.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the type is not <see cref="Nullable{T}" />.
        /// </exception>
        public override TypeResolution Resolve(Type type)
        {
            if (!IsMatch(type))
            {
                throw new ArgumentException($"The nullable case can only be applied to {typeof(Nullable<>).FullName}.", nameof(type));
            }

            var resolution = Resolver.ResolveType(Nullable.GetUnderlyingType(type));
            resolution.IsNullable = true;
            resolution.Type = type;

            return resolution;
        }
    }

    /// <summary>
    /// A general type resolver case that inspects fields and properties.
    /// </summary>
    public class ObjectResolverCase : ReflectionResolverCase
    {
        /// <summary>
        /// The binding flags that will be used to select fields and properties. Only public instance
        /// member are selected by default.
        /// </summary>
        protected readonly BindingFlags MemberVisibility;

        /// <summary>
        /// Creates a new object resolver case.
        /// </summary>
        /// <param name="memberVisibility">
        /// The binding flags that will be used to select fields and properties. If none are provided,
        /// public instance members will be selected by default.
        /// </param>
        public ObjectResolverCase(BindingFlags memberVisibility = BindingFlags.Public | BindingFlags.Instance)
        {
            MemberVisibility = memberVisibility;
        }

        /// <summary>
        /// Determines whether the case can be applied to a type.
        /// </summary>
        /// <returns>
        /// Whether the type is a class, interface, or struct.
        /// </returns>
        public override bool IsMatch(Type type)
        {
            return !type.IsArray && !type.IsPrimitive;
        }
        
        /// <summary>
        /// Resolves class, interface, or struct type information.
        /// </summary>
        /// <param name="type">
        /// The type to resolve.
        /// </param>
        /// <returns>
        /// A <see cref="RecordResolution" /> with information about the type.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the type is an array type or a primitive type.
        /// </exception>
        public override TypeResolution Resolve(Type type)
        {
            if (!IsMatch(type))
            {
                throw new ArgumentException("The object resolver can only be applied to non-array, non-primitive types.", nameof(type));
            }

            var name = new IdentifierResolution(type.Name);

            var @namespace = string.IsNullOrEmpty(type.Namespace)
                ? null
                : new IdentifierResolution(type.Namespace);

            var fields = Enumerable
                .Concat(
                    type.GetFields(MemberVisibility).Select(f => (f as MemberInfo, f.FieldType)),
                    type.GetProperties(MemberVisibility).Select(p => (p as MemberInfo, p.PropertyType))
                )
                .Select(r => new FieldResolution(r.Item1, r.Item2, new IdentifierResolution(r.Item1.Name)))
                .OrderBy(f => f.Name.Value)
                .ToList();

            return new RecordResolution(type, name, @namespace, fields);
        }
    }
    
    /// <summary>
    /// A type resolver case that matches <see cref="sbyte" />.
    /// </summary>
    public class SByteResolverCase : ReflectionResolverCase
    {
        /// <summary>
        /// Determines whether the case can be applied to a type.
        /// </summary>
        /// <returns>
        /// Whether the type is <see cref="sbyte" />.
        /// </returns>
        public override bool IsMatch(Type type)
        {
            return type == typeof(sbyte);
        }

        /// <summary>
        /// Resolves sbyte (8-bit signed integer) type information.
        /// </summary>
        /// <param name="type">
        /// The type to resolve.
        /// </param>
        /// <returns>
        /// An <see cref="IntegerResolution" /> with information about the type.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the type is not <see cref="sbyte" />.
        /// </exception>
        public override TypeResolution Resolve(Type type)
        {
            if (!IsMatch(type))
            {
                throw new ArgumentException($"The sbyte case can only be applied to {typeof(sbyte).FullName}.", nameof(type));
            }

            return new IntegerResolution(type, true, 8);
        }
    }

    /// <summary>
    /// A type resolver case that matches <see cref="float" />.
    /// </summary>
    public class SingleResolverCase : ReflectionResolverCase
    {
        /// <summary>
        /// Determines whether the case can be applied to a type.
        /// </summary>
        /// <returns>
        /// Whether the type is <see cref="float" />.
        /// </returns>
        public override bool IsMatch(Type type)
        {
            return type == typeof(float);
        }

        /// <summary>
        /// Resolves single-precision floating-point type information.
        /// </summary>
        /// <param name="type">
        /// The type to resolve.
        /// </param>
        /// <returns>
        /// A <see cref="FloatingPointResolution" /> with information about the type.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the type is not <see cref="float" />.
        /// </exception>
        public override TypeResolution Resolve(Type type)
        {
            if (!IsMatch(type))
            {
                throw new ArgumentException($"The float case can only be applied to {typeof(float).FullName}.", nameof(type));
            }

            return new FloatingPointResolution(type, 8);
        }
    }

    /// <summary>
    /// A type resolver that matches <see cref="string" />.
    /// </summary>
    public class StringResolverCase : ReflectionResolverCase
    {
        /// <summary>
        /// Determines whether the case can be applied to a type.
        /// </summary>
        /// <returns>
        /// Whether the type is <see cref="string" />.
        /// </returns>
        public override bool IsMatch(Type type)
        {
            return type == typeof(string);
        }

        /// <summary>
        /// Resolves string type information.
        /// </summary>
        /// <param name="type">
        /// The type to resolve.
        /// </param>
        /// <returns>
        /// A <see cref="StringResolution" /> with information about the type.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the type is not <see cref="string" />.
        /// </exception>
        public override TypeResolution Resolve(Type type)
        {
            if (!IsMatch(type))
            {
                throw new ArgumentException($"The string case can only be applied to {typeof(string).FullName}.", nameof(type));
            }

            return new StringResolution(type);
        }
    }

    /// <summary>
    /// A type resolver that matches <see cref="TimeSpan" />.
    /// </summary>
    public class TimeSpanResolverCase : ReflectionResolverCase
    {
        /// <summary>
        /// Determines whether the case can be applied to a type.
        /// </summary>
        /// <returns>
        /// Whether the type is <see cref="TimeSpan" />.
        /// </returns>
        public override bool IsMatch(Type type)
        {
            return type == typeof(TimeSpan);
        }

        /// <summary>
        /// Resolves duration type information.
        /// </summary>
        /// <param name="type">
        /// The type to resolve.
        /// </param>
        /// <returns>
        /// A <see cref="DurationResolution" /> with information about the type.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the type is not <see cref="TimeSpan" />.
        /// </exception>
        public override TypeResolution Resolve(Type type)
        {
            if (!IsMatch(type))
            {
                throw new ArgumentException($"The timespan case can only be applied to {typeof(TimeSpan).FullName}.", nameof(type));
            }

            return new DurationResolution(type, 1m / TimeSpan.TicksPerSecond);
        }
    }

    /// <summary>
    /// A type resolver case that matches <see cref="char" /> and <see cref="ushort" />.
    /// </summary>
    public class UInt16ResolverCase : ReflectionResolverCase
    {
        /// <summary>
        /// Determines whether the case can be applied to a type.
        /// </summary>
        /// <returns>
        /// Whether the type is <see cref="char" /> or <see cref="ushort" />.
        /// </returns>
        public override bool IsMatch(Type type)
        {
            return type == typeof(char) || type == typeof(ushort);
        }

        /// <summary>
        /// Resolves ushort (16-bit unsigned integer) type information.
        /// </summary>
        /// <param name="type">
        /// The type to resolve.
        /// </param>
        /// <returns>
        /// An <see cref="IntegerResolution" /> with information about the type.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the type is not <see cref="char" /> or <see cref="ushort" />.
        /// </exception>
        public override TypeResolution Resolve(Type type)
        {
            if (!IsMatch(type))
            {
                throw new ArgumentException($"The uint16 case can only be applied to {typeof(char).FullName} or {typeof(ushort).FullName}.", nameof(type));
            }

            return new IntegerResolution(type, false, 16);
        }
    }

    /// <summary>
    /// A type resolver case that matches <see cref="uint" />.
    /// </summary>
    public class UInt32ResolverCase : ReflectionResolverCase
    {
        /// <summary>
        /// Determines whether the case can be applied to a type.
        /// </summary>
        /// <returns>
        /// Whether the type is <see cref="uint" />.
        /// </returns>
        public override bool IsMatch(Type type)
        {
            return type == typeof(uint);
        }

        /// <summary>
        /// Resolves uint (32-bit unsigned integer) type information.
        /// </summary>
        /// <param name="type">
        /// The type to resolve.
        /// </param>
        /// <returns>
        /// An <see cref="IntegerResolution" /> with information about the type.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the type is not <see cref="uint" />.
        /// </exception>
        public override TypeResolution Resolve(Type type)
        {
            if (!IsMatch(type))
            {
                throw new ArgumentException($"The uint32 case can only be applied to {typeof(uint).FullName}.", nameof(type));
            }

            return new IntegerResolution(type, false, 32);
        }
    }

    /// <summary>
    /// A type resolver case that matches <see cref="ulong" />.
    /// </summary>
    public class UInt64ResolverCase : ReflectionResolverCase
    {
        /// <summary>
        /// Determines whether the case can be applied to a type.
        /// </summary>
        /// <returns>
        /// Whether the type is <see cref="ulong" />.
        /// </returns>
        public override bool IsMatch(Type type)
        {
            return type == typeof(ulong);
        }

        /// <summary>
        /// Resolves ulong (64-bit unsigned integer) type information.
        /// </summary>
        /// <param name="type">
        /// The type to resolve.
        /// </param>
        /// <returns>
        /// An <see cref="IntegerResolution" /> with information about the type.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the type is not <see cref="ulong" />.
        /// </exception>
        public override TypeResolution Resolve(Type type)
        {
            if (!IsMatch(type))
            {
                throw new ArgumentException($"The uint64 case can only be applied to {typeof(ulong).FullName}.", nameof(type));
            }

            return new IntegerResolution(type, false, 64);
        }
    }

    /// <summary>
    /// A type resolver case that matches <see cref="Uri" />.
    /// </summary>
    public class UriResolverCase : ReflectionResolverCase
    {
        /// <summary>
        /// Determines whether the case can be applied to a type.
        /// </summary>
        /// <returns>
        /// Whether the type is <see cref="Uri" />.
        /// </returns>
        public override bool IsMatch(Type type)
        {
            return type == typeof(Uri);
        }

        /// <summary>
        /// Resolves URI type information.
        /// </summary>
        /// <param name="type">
        /// The type to resolve.
        /// </param>
        /// <returns>
        /// A <see cref="UriResolution" /> with information about the type.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the type is not <see cref="Uri" />.
        /// </exception>
        public override TypeResolution Resolve(Type type)
        {
            if (!IsMatch(type))
            {
                throw new ArgumentException($"The URI case can only be applied to {typeof(Uri).FullName}.", nameof(type));
            }

            return new UriResolution(type);
        }
    }
}
