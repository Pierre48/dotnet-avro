(window.webpackJsonp=window.webpackJsonp||[]).push([[11],{"1+7Q":function(e,n){e.exports={groupBy:function(e,n){return e.reduce((function(e,r){var t=r[n];return e.has(r[n])||e.set(t,[]),e.get(t).push(r),e}),new Map)},join:function(e,n){return e.reduce((function(e,r,t,a){return e.push(r),t<a.length-1&&e.push(n),e}),[])}}},CYc0:function(e,n,r){"use strict";r.r(n);var t=r("Wbzz"),a=r("q1tI"),s=r.n(a),i=r("qhky"),o=r("rCNW"),c=r("KwlC"),l=r("zLVn"),u=r("w+gZ");function m(e){var n=e.children,r=e.id,t=e.version,a=Object(l.a)(e,["children","id","version"]),i="https://www.nuget.org/packages/"+r;return t&&(i+="/"+t),s.a.createElement(u.a,Object.assign({},a,{to:i}),n||r)}var p="Building Kafka producers and consumers";n.default=function(){var e=Object(t.d)("4092712757").site.siteMetadata,n=e.latestRelease,r=e.projectName;return s.a.createElement(s.a.Fragment,null,s.a.createElement(i.a,null,s.a.createElement("title",null,p)),s.a.createElement("h1",null,p),s.a.createElement("p",null,r," ships with first-class support for ",s.a.createElement(u.a,{to:"https://github.com/confluentinc/confluent-kafka-dotnet"},"Confluent’s Kafka clients"),", the shortest path to creating Kafka producers and consumers in .NET."),s.a.createElement("h2",null,"Using Confluent’s client builders"),s.a.createElement("p",null,"First, add a reference to the Chr.Avro.Confluent package:"),s.a.createElement(o.a,{language:"bash"},"$ dotnet add package Chr.Avro.Confluent --version "+n),s.a.createElement("p",null,"Chr.Avro.Confluent depends on ",s.a.createElement(m,{id:"Confluent.Kafka"}),", which contains ",s.a.createElement(c.a,{id:"T:Confluent.Kafka.ProducerBuilder`2"},"producer")," and ",s.a.createElement(c.a,{id:"T:Confluent.Kafka.ConsumerBuilder`2"},"consumer")," builders. To build a ",s.a.createElement(u.a,{to:"https://www.confluent.io/confluent-schema-registry/"},"Schema Registry"),"-integrated producer, use the producer builder in tandem with ",r,"’s Avro extension methods:"),s.a.createElement(o.a,{language:"csharp"},'using Chr.Avro.Confluent;\nusing Confluent.Kafka;\nusing Confluent.SchemaRegistry;\nusing System;\nusing System.Threading.Tasks;\n\nnamespace Chr.Avro.Examples.KafkaProducer\n{\n    public class ExampleValue\n    {\n        public string Property { get; set; }\n    }\n\n    public class Program\n    {\n        public static async Task Main(string[] args)\n        {\n            var producerConfig = new ProducerConfig()\n            {\n                BootstrapServers = "broker1:9092,broker2:9092"\n            };\n\n            var registryConfig = new RegistryConfig()\n            {\n                SchemaRegistryUrl = "http://registry:8081"\n            };\n\n            using (var registry = new CachedSchemaRegistryClient(registryConfig))\n            {\n                var builder = new ProducerBuilder<Ignore, ExampleValue>(producerConfig)\n                    .SetAvroValueSerializer(registry, registerAutomatically: AutomaticRegistrationBehavior.Always)\n                    .SetErrorHandler((_, error) => Console.Error.WriteLine(error.ToString()));\n\n                using (var producer = builder.Build())\n                {\n                    await producer.ProduceAsync("example_topic", new Message<Ignore, ExampleValue>\n                    {\n                        Value = new ExampleValue\n                        {\n                            Property = "example!"\n                        }\n                    });\n                }\n            }\n        }\n    }\n}'),s.a.createElement("p",null,"The serializer assumes (per Confluent convention) that the value subject for ",s.a.createElement("code",null,"example_topic")," is ",s.a.createElement("code",null,"example_topic-value"),". (The key subject would be ",s.a.createElement("code",null,"example_topic-key"),".) When messages are published, the serializer will attempt to pull down a schema from the Schema Registry. The serializer can be configured to generate and register a schema automatically if one doesn’t exist."),s.a.createElement("p",null,"Building consumers works in a similar way—schemas will be retrieved from the Schema Registry as messages are consumed:"),s.a.createElement(o.a,{language:"csharp"},'using Chr.Avro.Confluent;\nusing Confluent.Kafka;\nusing Confluent.SchemaRegistry;\nusing System;\n\nnamespace Chr.Avro.Examples.KafkaConsumer\n{\n    public class ExampleValue\n    {\n        public string Property { get; set; }\n    }\n\n    public class Program\n    {\n        public static void Main(string[] args)\n        {\n            var consumerConfig = new ConsumerConfig()\n            {\n                BootstrapServers = "broker1:9092,broker2:9092",\n                GroupId = "example_consumer_group"\n            };\n\n            var registryConfig = new RegistryConfig()\n            {\n                SchemaRegistryUrl = "http://registry:8081"\n            };\n\n            using (var registry = new CachedSchemaRegistryClient(registryClient))\n            {\n                var builder = new ConsumerBuilder<Ignore, ExampleValue>(consumerConfig)\n                    .SetAvroValueDeserializer(registry)\n                    .SetErrorHandler((_, error) => Console.Error.WriteLine(error.ToString()));\n\n                using (var consumer = builder.Build())\n                {\n                    consumer.Subscribe("example_topic");\n\n                    while (true)\n                    {\n                        var result = consumer.Consume();\n                        Console.WriteLine(result.Value.Property);\n                    }\n                }\n            }\n        }\n    }\n}'))}},KwlC:function(e,n,r){"use strict";r.d(n,"a",(function(){return d}));var t=r("zLVn"),a=r("KQm4"),s=r("Wbzz"),i=r("q1tI"),o=r.n(i),c=r("w+gZ"),l=r("1+7Q"),u=r("oyoe");function m(e){var n=e.id,r=e.typeParameters,t=void 0===r?[]:r,s=e.methodTypeParameters,i=void 0===s?[]:s;switch(n.substring(0,2)){case"F:":case"P:":return o.a.createElement(p,{id:n},Object(u.createMemberName)(n));case"M:":var c=[o.a.createElement(p,{key:n,id:n},Object(u.createMemberName)(n))];return i&&i.length&&c.push.apply(c,["<"].concat(Object(a.a)(Object(l.join)(i,", ")),[">"])),c.push.apply(c,["("].concat(Object(a.a)(Object(l.join)(Object(u.getMethodParameters)(n).map((function(e,n){return o.a.createElement(m,{key:n,id:"T:"+e,typeParameters:t,methodTypeParameters:i})})),", ")),[")"])),c;case"T:":var d=n.match(/^T:`(\d+)$/),g=n.match(/^T:``(\d+)$/);if(d)return t[d[1]]||"";if(g)return i[g[1]]||"";var h=[o.a.createElement(p,{key:n,id:n},Object(u.createTypeName)(n))],f=Object(u.getTypeParameters)(n),y=n.match(/^T:(.+)`(\d+)$/);return(f||y)&&(h.push("<"),f&&h.push.apply(h,Object(a.a)(Object(l.join)(f.map((function(e,n){return o.a.createElement(m,{key:n,id:"T:"+e,typeParameters:t,methodTypeParameters:i})})),", "))),y&&(n=y[1],h.push(new Array(+y[2]).join(","))),h.push(">")),h.push(Object(u.getTypeSuffix)(n)),h;default:return o.a.createElement(p,{id:n},n.substring(2))}}function p(e){var n=e.children,r=e.id;return/^[EFMNPT]:Chr\.Avro/.test(r)?o.a.createElement(s.a,{to:"/api/"+Object(u.createDocfxUrl)(r).toLowerCase()},n):/^[EFMNPT]:Confluent\.(?:Kafka|SchemaRegistry)/.test(r)?o.a.createElement(c.a,{to:"https://docs.confluent.io/current/clients/confluent-kafka-dotnet/api/"+Object(u.createDocfxUrl)(r)+".html"},n):/^[EFMNPT]:(?:Microsoft|System)/.test(r)?o.a.createElement(c.a,{to:"https://docs.microsoft.com/en-us/dotnet/api/"+Object(u.createDocfxUrl)(r).toLowerCase()},n):n}function d(e){var n=e.children,r=e.id,a=e.typeParameters,s=e.methodTypeParameters,i=Object(t.a)(e,["children","id","typeParameters","methodTypeParameters"]);return n?o.a.createElement(p,Object.assign({id:r},i),n):o.a.createElement("code",i,o.a.createElement(m,{id:r,typeParameters:a,methodTypeParameters:s}))}}}]);
//# sourceMappingURL=component---src-pages-guides-kafka-js-d92cb56d20f3978d33f9.js.map