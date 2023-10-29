var j=Object.defineProperty;var B=Object.getOwnPropertySymbols;var q=Object.prototype.hasOwnProperty,O=Object.prototype.propertyIsEnumerable;var w=(s,a,u)=>a in s?j(s,a,{enumerable:!0,configurable:!0,writable:!0,value:u}):s[a]=u,E=(s,a)=>{for(var u in a||(a={}))q.call(a,u)&&w(s,u,a[u]);if(B)for(var u of B(a))O.call(a,u)&&w(s,u,a[u]);return s};var h=(s,a,u)=>new Promise((m,v)=>{var C=l=>{try{p(u.next(l))}catch(c){v(c)}},i=l=>{try{p(u.throw(l))}catch(c){v(c)}},p=l=>l.done?m(l.value):Promise.resolve(l.value).then(C,i);p((u=u.apply(s,a)).next())});import{d as V,f as $,g as Z,u as G,eZ as H,ae as J,r as F,b as K,c0 as Q,c2 as W,o as X,c as Y,i as e,w as t,c4 as ee,h as A,j as f,cF as te,k as ue,_ as oe,m as ae,ca as le,N as ne,l as se,c6 as re,c7 as ie,cb as ce}from"./index.9b095fa3.js";import{_ as de}from"./product-item-form.vue_vue_type_script_setup_true_lang.86682521.js";import{productItemColumns as pe}from"./datas.93f51761.js";import{B as me}from"./TableAction.vue_vue_type_script_lang.3072adbb.js";import{T as _e}from"./TableAction.c2e71baa.js";import{g as fe,u as ve,c as Ce}from"./index.65a1a773.js";import{P as Fe}from"./PlusOutlined.f00db73b.js";import"./vuedraggable.umd.9403b4da.js";import"./useDesignSetting.5aac35a0.js";import"./SettingOutlined.8ddd14cb.js";import"./propTypes.950ac77d.js";import"./FormOutlined.a8df660c.js";import"./ReloadOutlined.8b3017bd.js";import"./componentSetting.e6bd74f7.js";import"./index.8bd93700.js";import"./DownOutlined.2ffc076e.js";const ze=V({__name:"create",setup(s){const a=$(),u=Z(),m=G(),v=H(),C=u.query.productId,i=J(()=>C!==void 0),p=F(),l=F(!1),c=F({}),k={description:{required:!0,trigger:["blur","input"],message:"\u8BF7\u8F93\u5165\u4EA7\u54C1\u63CF\u8FF0"},entryCriteria:{required:!0,trigger:["blur","input"],message:"\u8BF7\u8F93\u5165\u5165\u7EA7\u63CF\u8FF0"}},x=K({width:200,title:"\u64CD\u4F5C",key:"action",fixed:"right",align:"center",render(d){return console.log(d),Q(_e,{style:"button",actions:[{label:"\u5220\u9664",onClick:()=>{o.value.productListItemDtos=o.value.productListItemDtos.filter(n=>n.id!=d.id)},ifShow:!0}]})}});let g={id:null,description:null,entryCriteria:null,productListItemDtos:[]};const o=F(E({},g)),T=()=>{console.log("\u70B9\u51FB\u4E86\u8FD4\u56DE\u4EA7\u54C1\u5217\u8868\u9875"),a.push({name:"product-list"})},L=()=>{l.value=!0,c.value={}},P=()=>{l.value=!1},N=()=>{o.value.productListItemDtos.push(c.value),l.value=!1},R=d=>{d.preventDefault(),l.value=!1,p.value.validate(n=>h(this,null,function*(){if(n)m.error("\u64CD\u4F5C\u5931\u8D25");else{if(!o.value.productListItemDtos||o.value.productListItemDtos.length<1){m.error("\u8BF7\u6DFB\u52A0\u4EA7\u54C1\u9879");return}v.info({title:"\u63D0\u793A",content:"\u786E\u8BA4\u63D0\u4EA4\u5417?",positiveText:"\u786E\u5B9A",negativeText:"\u53D6\u6D88",onPositiveClick:()=>h(this,null,function*(){i.value?yield ve(o.value):yield Ce(o.value),m.success(i.value?"\u7F16\u8F91\u6210\u529F":"\u65B0\u5EFA\u6210\u529F"),setTimeout(()=>{a.push({name:"product-list"})},2e3)}),onNegativeClick:()=>{}})}}))};return W(()=>{fe().then(d=>{g=d.filter(n=>n.id==C)[0],o.value=E({},g),console.log(o.value)})}),(d,n)=>{const z=te,b=ue,y=oe,M=ae,D=le,S=ne,_=se,I=re,U=ie;return X(),Y("div",null,[e(D,{bordered:!1,class:"mt-4 proCard",size:"small",segmented:{content:!0}},{default:t(()=>[e(M,{model:o.value,ref_key:"productFormRef",ref:p,"label-placement":"left","label-width":"auto",inline:"",rules:k,class:"py-4"},{default:t(()=>[ee(e(b,{label:"\u5BA2\u6237Id",path:"id",hidden:""},{default:t(()=>[e(z,{clearable:"",disabled:i.value,placeholder:"\u5BA2\u6237Id",readonly:"",value:o.value.id,"onUpdate:value":n[0]||(n[0]=r=>o.value.id=r),hidden:""},null,8,["disabled","value"])]),_:1},512),[[ce,!1]]),e(b,{label:"\u4EA7\u54C1\u63CF\u8FF0",path:"description"},{default:t(()=>[e(y,{disabled:i.value,clearable:"",placeholder:"\u4EA7\u54C1\u63CF\u8FF0",value:o.value.description,"onUpdate:value":n[1]||(n[1]=r=>o.value.description=r)},null,8,["disabled","value"])]),_:1}),e(b,{label:"\u5165\u7EA7\u63CF\u8FF0",path:"entryCriteria"},{default:t(()=>[e(y,{disabled:i.value,clearable:"",placeholder:"\u5165\u7EA7\u63CF\u8FF0",value:o.value.entryCriteria,"onUpdate:value":n[2]||(n[2]=r=>o.value.entryCriteria=r)},null,8,["disabled","value"])]),_:1})]),_:1},8,["model"])]),_:1}),e(D,{bordered:!1,class:"mt-4 proCard",size:"small",segmented:{content:!0}},{default:t(()=>[e(A(me),{columns:A(pe),"row-key":r=>r.id,ref:"actionRef",dataSource:o.value.productListItemDtos,actionColumn:x,"scroll-x":1090,pagination:!1,showToolBar:!1},{tableTitle:t(()=>[e(_,{type:"primary",onClick:L},{icon:t(()=>[e(S,null,{default:t(()=>[e(A(Fe))]),_:1})]),default:t(()=>[f(" \u6DFB\u52A0\u4EA7\u54C1\u660E\u7EC6 ")]),_:1})]),_:1},8,["columns","row-key","dataSource","actionColumn"])]),_:1}),e(U,{show:l.value,"onUpdate:show":n[3]||(n[3]=r=>l.value=r),"show-icon":!1,preset:"card",size:"huge",style:{width:"800px"},title:"\u65B0\u5EFA\u4EA7\u54C1\u660E\u7EC6"},{footer:t(()=>[e(I,{justify:"center"},{default:t(()=>[e(_,{onClick:P},{default:t(()=>[f("\u53D6\u6D88")]),_:1}),e(_,{type:"info",onClick:N},{default:t(()=>[f("\u786E\u5B9A")]),_:1})]),_:1})]),default:t(()=>[e(de,{item:c.value},null,8,["item"])]),_:1},8,["show"]),e(D,{bordered:!1,class:"mt-4 proCard",size:"small",segmented:{content:!0}},{default:t(()=>[e(I,{justify:"center"},{default:t(()=>[e(_,{type:"default",onClick:T},{default:t(()=>[f(" \u8FD4\u56DE ")]),_:1}),e(_,{type:"success",onClick:R},{default:t(()=>[f(" \u63D0\u4EA4 ")]),_:1})]),_:1})]),_:1})])}}});export{ze as default};
