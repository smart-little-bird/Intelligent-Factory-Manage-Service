var E=Object.defineProperty;var _=Object.getOwnPropertySymbols;var T=Object.prototype.hasOwnProperty,D=Object.prototype.propertyIsEnumerable;var h=(t,u,e)=>u in t?E(t,u,{enumerable:!0,configurable:!0,writable:!0,value:e}):t[u]=e,d=(t,u)=>{for(var e in u||(u={}))T.call(u,e)&&h(t,e,u[e]);if(_)for(var e of _(u))D.call(u,e)&&h(t,e,u[e]);return t};var f=(t,u,e)=>new Promise((s,r)=>{var c=n=>{try{i(e.next(n))}catch(a){r(a)}},l=n=>{try{i(e.throw(n))}catch(a){r(a)}},i=n=>n.done?s(n.value):Promise.resolve(n.value).then(c,l);i((e=e.apply(t,u)).next())});import{B as A}from"./TableAction.vue_vue_type_script_lang.3072adbb.js";import{T as N}from"./TableAction.c2e71baa.js";import{g as z}from"./list.65ddd744.js";import{d as F,o as g,c as L,a as M,c0 as p,fT as R,d3 as O,u as S,eZ as V,r as j,b as w,c3 as q,w as m,i as k,h as y,j as H,l as K,ca as P}from"./index.9b095fa3.js";import{D as U}from"./DeleteOutlined.c82a0970.js";import"./vuedraggable.umd.9403b4da.js";import"./useDesignSetting.5aac35a0.js";import"./SettingOutlined.8ddd14cb.js";import"./propTypes.950ac77d.js";import"./FormOutlined.a8df660c.js";import"./ReloadOutlined.8b3017bd.js";import"./componentSetting.e6bd74f7.js";import"./index.8bd93700.js";import"./DownOutlined.2ffc076e.js";const Z={xmlns:"http://www.w3.org/2000/svg","xmlns:xlink":"http://www.w3.org/1999/xlink",viewBox:"0 0 1024 1024"},$=M("path",{d:"M257.7 752c2 0 4-.2 6-.5L431.9 722c2-.4 3.9-1.3 5.3-2.8l423.9-423.9a9.96 9.96 0 0 0 0-14.1L694.9 114.9c-1.9-1.9-4.4-2.9-7.1-2.9s-5.2 1-7.1 2.9L256.8 538.8c-1.5 1.5-2.4 3.3-2.8 5.3l-29.5 168.2a33.5 33.5 0 0 0 9.4 29.8c6.6 6.4 14.9 9.9 23.8 9.9zm67.4-174.4L687.8 215l73.3 73.3l-362.7 362.6l-88.9 15.7l15.6-89zM880 836H144c-17.7 0-32 14.3-32 32v36c0 4.4 3.6 8 8 8h784c4.4 0 8-3.6 8-8v-36c0-17.7-14.3-32-32-32z",fill:"currentColor"},null,-1),G=[$],I=F({name:"EditOutlined",render:function(u,e){return g(),L("svg",Z,G)}}),J=[{title:"id",key:"id",width:100},{title:"\u7F16\u7801",key:"no",width:100},{title:"\u540D\u79F0",key:"name",width:100},{title:"\u5934\u50CF",key:"avatar",width:100,render(t){return p(R,{size:48,src:t.avatar})}},{title:"\u5730\u5740",key:"address",width:150},{title:"\u5F00\u59CB\u65E5\u671F",key:"beginTime",width:160},{title:"\u7ED3\u675F\u65E5\u671F",key:"endTime",width:160},{title:"\u72B6\u6001",key:"status",width:100,render(t){return p(O,{type:t.status?"success":"error"},{default:()=>t.status?"\u542F\u7528":"\u7981\u7528"})}},{title:"\u521B\u5EFA\u65F6\u95F4",key:"date",width:160},{title:"\u505C\u7559\u65F6\u95F4",key:"time",width:80}],me=F({__name:"basic",setup(t){const u=S(),e=V(),s=j(),r=w({pageSize:5,name:"xiaoMa"}),c=w({width:150,title:"\u64CD\u4F5C",key:"action",fixed:"right",align:"center",render(o){return p(N,{style:"text",actions:l(o)})}});function l(o){return[{label:"\u5220\u9664",type:"error",color:"red",icon:U,onClick:C.bind(null,o),ifShow:()=>!0,auth:["basic_list"]},{label:"\u7F16\u8F91",type:"primary",icon:I,onClick:b.bind(null,o),ifShow:()=>!0,auth:["basic_list"]}]}const i=o=>f(this,null,function*(){return yield z(d(d({},r),o))});function n(o){console.log(o)}function a(){s.value.reload()}function C(o){console.log(o),e.info({title:"\u63D0\u793A",content:`\u60A8\u60F3\u5220\u9664${o.name}`,positiveText:"\u786E\u5B9A",negativeText:"\u53D6\u6D88",onPositiveClick:()=>{u.success("\u5220\u9664\u6210\u529F")},onNegativeClick:()=>{}})}function b(o){console.log(o),u.success("\u60A8\u70B9\u51FB\u4E86\u7F16\u8F91\u6309\u94AE")}return(o,Q)=>{const x=K,v=P;return g(),q(v,{bordered:!1,class:"proCard"},{default:m(()=>[k(y(A),{title:"\u8868\u683C\u5217\u8868",titleTooltip:"\u8FD9\u662F\u4E00\u4E2A\u63D0\u793A",columns:y(J),request:i,"row-key":B=>B.id,ref_key:"actionRef",ref:s,actionColumn:c,"scroll-x":1360,"onUpdate:checkedRowKeys":n},{toolbar:m(()=>[k(x,{type:"primary",onClick:a},{default:m(()=>[H("\u5237\u65B0\u6570\u636E")]),_:1})]),_:1},8,["columns","row-key","actionColumn"])]),_:1})}}});export{me as default};
