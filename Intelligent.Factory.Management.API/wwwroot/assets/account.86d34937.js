import{_ as E}from"./BasicSetting.vue_vue_type_script_setup_true_lang.b2a30507.js";import k from"./SafetySetting.2771bacd.js";import{d as C,r as l,o as s,c as r,i as n,w as e,cY as F,cX as v,cy as h,j as p,t as i,c3 as d,cR as m,g7 as x,ca as A,fq as T,fs as b,n as w}from"./index.9b095fa3.js";const z=C({__name:"account",setup(N){const f=[{name:"\u57FA\u672C\u8BBE\u7F6E",desc:"\u4E2A\u4EBA\u8D26\u6237\u4FE1\u606F\u8BBE\u7F6E",key:1},{name:"\u5B89\u5168\u8BBE\u7F6E",desc:"\u5BC6\u7801\uFF0C\u90AE\u7BB1\u7B49\u8BBE\u7F6E",key:2}],a=l(1),o=l("\u57FA\u672C\u8BBE\u7F6E");function B(c){a.value=c.key,o.value=c.name}return(c,S)=>{const y=x,u=A,_=T,g=b;return s(),r("div",null,[n(g,{"x-gap":24},{default:e(()=>[n(_,{span:"6"},{default:e(()=>[n(u,{bordered:!1,size:"small",class:"proCard"},{default:e(()=>[(s(),r(F,null,v(f,t=>n(y,{class:h(["thing-cell",{"thing-cell-on":a.value===t.key}]),key:t.key,onClick:V=>B(t)},{header:e(()=>[p(i(t.name),1)]),description:e(()=>[p(i(t.desc),1)]),_:2},1032,["class","onClick"])),64))]),_:1})]),_:1}),n(_,{span:"18"},{default:e(()=>[n(u,{bordered:!1,size:"small",title:o.value,class:"proCard"},{default:e(()=>[a.value===1?(s(),d(E,{key:0})):m("",!0),a.value===2?(s(),d(k,{key:1})):m("",!0)]),_:1},8,["title"])]),_:1})]),_:1})])}}});const j=w(z,[["__scopeId","data-v-94f6997f"]]);export{j as default};