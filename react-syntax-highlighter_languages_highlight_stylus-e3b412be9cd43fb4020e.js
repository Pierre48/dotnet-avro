(window.webpackJsonp=window.webpackJsonp||[]).push([[187],{vchd:function(e,t){e.exports=function(e){var t={className:"variable",begin:"\\$"+e.IDENT_RE},i={className:"number",begin:"#([a-fA-F0-9]{6}|[a-fA-F0-9]{3})"};return{name:"Stylus",aliases:["styl"],case_insensitive:!1,keywords:"if else for in",illegal:"("+["\\?","(\\bReturn\\b)","(\\bEnd\\b)","(\\bend\\b)","(\\bdef\\b)",";","#\\s","\\*\\s","===\\s","\\|","%"].join("|")+")",contains:[e.QUOTE_STRING_MODE,e.APOS_STRING_MODE,e.C_LINE_COMMENT_MODE,e.C_BLOCK_COMMENT_MODE,i,{begin:"\\.[a-zA-Z][a-zA-Z0-9_-]*(?=[\\.\\s\\n\\[\\:,])",className:"selector-class"},{begin:"\\#[a-zA-Z][a-zA-Z0-9_-]*(?=[\\.\\s\\n\\[\\:,])",className:"selector-id"},{begin:"\\b("+["a","abbr","address","article","aside","audio","b","blockquote","body","button","canvas","caption","cite","code","dd","del","details","dfn","div","dl","dt","em","fieldset","figcaption","figure","footer","form","h1","h2","h3","h4","h5","h6","header","hgroup","html","i","iframe","img","input","ins","kbd","label","legend","li","mark","menu","nav","object","ol","p","q","quote","samp","section","span","strong","summary","sup","table","tbody","td","textarea","tfoot","th","thead","time","tr","ul","var","video"].join("|")+")(?=[\\.\\s\\n\\[\\:,])",className:"selector-tag"},{begin:"&?:?:\\b("+["after","before","first-letter","first-line","active","first-child","focus","hover","lang","link","visited"].join("|")+")(?=[\\.\\s\\n\\[\\:,])"},{begin:"@("+["charset","css","debug","extend","font-face","for","import","include","media","mixin","page","warn","while"].join("|")+")\\b"},t,e.CSS_NUMBER_MODE,e.NUMBER_MODE,{className:"function",begin:"^[a-zA-Z][a-zA-Z0-9_-]*\\(.*\\)",illegal:"[\\n]",returnBegin:!0,contains:[{className:"title",begin:"\\b[a-zA-Z][a-zA-Z0-9_-]*"},{className:"params",begin:/\(/,end:/\)/,contains:[i,t,e.APOS_STRING_MODE,e.CSS_NUMBER_MODE,e.NUMBER_MODE,e.QUOTE_STRING_MODE]}]},{className:"attribute",begin:"\\b("+["align-content","align-items","align-self","animation","animation-delay","animation-direction","animation-duration","animation-fill-mode","animation-iteration-count","animation-name","animation-play-state","animation-timing-function","auto","backface-visibility","background","background-attachment","background-clip","background-color","background-image","background-origin","background-position","background-repeat","background-size","border","border-bottom","border-bottom-color","border-bottom-left-radius","border-bottom-right-radius","border-bottom-style","border-bottom-width","border-collapse","border-color","border-image","border-image-outset","border-image-repeat","border-image-slice","border-image-source","border-image-width","border-left","border-left-color","border-left-style","border-left-width","border-radius","border-right","border-right-color","border-right-style","border-right-width","border-spacing","border-style","border-top","border-top-color","border-top-left-radius","border-top-right-radius","border-top-style","border-top-width","border-width","bottom","box-decoration-break","box-shadow","box-sizing","break-after","break-before","break-inside","caption-side","clear","clip","clip-path","color","column-count","column-fill","column-gap","column-rule","column-rule-color","column-rule-style","column-rule-width","column-span","column-width","columns","content","counter-increment","counter-reset","cursor","direction","display","empty-cells","filter","flex","flex-basis","flex-direction","flex-flow","flex-grow","flex-shrink","flex-wrap","float","font","font-family","font-feature-settings","font-kerning","font-language-override","font-size","font-size-adjust","font-stretch","font-style","font-variant","font-variant-ligatures","font-weight","height","hyphens","icon","image-orientation","image-rendering","image-resolution","ime-mode","inherit","initial","justify-content","left","letter-spacing","line-height","list-style","list-style-image","list-style-position","list-style-type","margin","margin-bottom","margin-left","margin-right","margin-top","marks","mask","max-height","max-width","min-height","min-width","nav-down","nav-index","nav-left","nav-right","nav-up","none","normal","object-fit","object-position","opacity","order","orphans","outline","outline-color","outline-offset","outline-style","outline-width","overflow","overflow-wrap","overflow-x","overflow-y","padding","padding-bottom","padding-left","padding-right","padding-top","page-break-after","page-break-before","page-break-inside","perspective","perspective-origin","pointer-events","position","quotes","resize","right","tab-size","table-layout","text-align","text-align-last","text-decoration","text-decoration-color","text-decoration-line","text-decoration-style","text-indent","text-overflow","text-rendering","text-shadow","text-transform","text-underline-position","top","transform","transform-origin","transform-style","transition","transition-delay","transition-duration","transition-property","transition-timing-function","unicode-bidi","vertical-align","visibility","white-space","widows","width","word-break","word-spacing","word-wrap","z-index"].reverse().join("|")+")\\b",starts:{end:/;|$/,contains:[i,t,e.APOS_STRING_MODE,e.QUOTE_STRING_MODE,e.CSS_NUMBER_MODE,e.NUMBER_MODE,e.C_BLOCK_COMMENT_MODE],illegal:/\./,relevance:0}}]}}}}]);
//# sourceMappingURL=react-syntax-highlighter_languages_highlight_stylus-e3b412be9cd43fb4020e.js.map