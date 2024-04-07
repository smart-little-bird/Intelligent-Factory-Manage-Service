var z=Object.defineProperty,J=Object.defineProperties;var K=Object.getOwnPropertyDescriptors;var x=Object.getOwnPropertySymbols;var Q=Object.prototype.hasOwnProperty,Z=Object.prototype.propertyIsEnumerable;var L=(e,u,o)=>u in e?z(e,u,{enumerable:!0,configurable:!0,writable:!0,value:o}):e[u]=o,B=(e,u)=>{for(var o in u||(u={}))Q.call(u,o)&&L(e,o,u[o]);if(x)for(var o of x(u))Z.call(u,o)&&L(e,o,u[o]);return e},P=(e,u)=>J(e,K(u));var w=(e,u,o)=>new Promise((p,r)=>{var f=l=>{try{s(o.next(l))}catch(m){r(m)}},t=l=>{try{s(o.throw(l))}catch(m){r(m)}},s=l=>l.done?p(l.value):Promise.resolve(l.value).then(f,t);s((o=o.apply(e,u)).next())});import{c7 as O,d as V,er as ee,r as v,ae as R,h as y,o as U,c3 as ue,cW as oe,w as c,i as a,j as E,t as N,cV as T,a as k,cS as te,dY as $,l as Y,c6 as X,g0 as ne,cP as se,cE as le,g4 as ae,u as ce,b as ie,cw as re,n as de,c as pe,ca as fe,fN as me,cB as Fe,_ as _e}from"./index.ff5a668a.js";import{B as W}from"./BasicForm.e6f0a73e.js";import{a as ge}from"./index.ae498cec.js";import{u as Ce}from"./useForm.43efa066.js";import"./propTypes.54b06ce7.js";import"./DownOutlined.67d87310.js";const Be=P(B({},O.props),{subBtuText:{type:String,default:"\u786E\u8BA4"},showIcon:{type:Boolean,default:!1},width:{type:Number,default:446},title:{type:String,default:""},maskClosable:{type:Boolean,default:!1},preset:{type:String,default:"dialog"}}),M=function(e,u){var o;return e.currentStyle?e.currentStyle[u]:(o=document.defaultView)==null?void 0:o.getComputedStyle(e,null)[u]},i={left:0,top:0,currentX:0,currentY:0,flag:!1},Ee=function(e,u,o){const p=document.body.clientWidth,r=document.documentElement.clientHeight,f=u.offsetWidth,t=u.offsetHeight,s=u.offsetLeft,l=u.offsetTop,m=p-s-f,_=r-l-t;M(u,"left")!=="auto"&&(i.left=M(u,"left")),M(u,"top")!=="auto"&&(i.top=M(u,"top")),e.onmousedown=function(d){i.flag=!0,d||(d=window.event,e.onselectstart=function(){return!1});const F=d;i.currentX=F.clientX,i.currentY=F.clientY},document.onmouseup=function(){i.flag=!1,M(u,"left")!=="auto"&&(i.left=M(u,"left")),M(u,"top")!=="auto"&&(i.top=M(u,"top"))},document.onmousemove=function(d){const F=d||window.event;if(i.flag){const g=F.clientX,b=F.clientY,C=g-i.currentX,h=b-i.currentY;let D=parseInt(i.left)+C,n=parseInt(i.top)+h;return-D>s?D=-s:D>m&&(D=m),-n>l?n=-l:n>_&&(n=_),u.style.left=D+"px",u.style.top=n+"px",typeof o=="function"&&o((parseInt(i.left)||0)+C,(parseInt(i.top)||0)+h),d.preventDefault&&d.preventDefault(),!1}}},be={class:"w-full cursor-move",id:"basic-modal-bar"},H=V({__name:"basicModal",props:B({},Be),emits:["on-close","on-ok","register"],setup(e,{emit:u}){const o=e,p=ee(),r=v(null),f=v(!1),t=v(!1),s=R(()=>B(B({},o),y(r))),l=R(()=>{const{subBtuText:n}=r.value;return n||o.subBtuText});function m(n){return w(this,null,function*(){r.value=ne(y(r)||{},n)})}const _=R(()=>B(B(B({},p),y(s)),y(r)));function d(n){t.value=n}function F(){f.value=!0,se(()=>{const n=document.getElementById("basic-modal"),A=document.getElementById("basic-modal-bar");Ee(A,n)})}function g(){f.value=!1,t.value=!1,u("on-close")}function b(){f.value=!1,u("on-close")}function C(){t.value=!0,u("on-ok")}const h={setProps:m,openModal:F,closeModal:g,setSubLoading:d};return $()&&u("register",h),(n,A)=>{const S=Y,j=X,G=O;return U(),ue(G,te({id:"basic-modal"},_.value,{show:f.value,"onUpdate:show":A[0]||(A[0]=q=>f.value=q),onClose:b}),oe({header:c(()=>[k("div",be,N(_.value.title),1)]),default:c(()=>[T(n.$slots,"default")]),_:2},[n.$slots.action?{name:"action",fn:c(()=>[T(n.$slots,"action")]),key:"1"}:{name:"action",fn:c(()=>[a(j,null,{default:c(()=>[a(S,{onClick:g},{default:c(()=>[E("\u53D6\u6D88")]),_:1}),a(S,{type:"primary",loading:t.value,onClick:C},{default:c(()=>[E(N(l.value),1)]),_:1},8,["loading"])]),_:1})]),key:"0"}]),1040,["show"])}}});function I(e){const u=v(null),o=$(),p=()=>{const t=y(u.value);return t||console.error("useModal instance is undefined!"),t};return[t=>{ge(()=>{u.value=null}),u.value=t,o==null||o.emit("register",t),le(()=>e,()=>{e&&t.setProps(ae(e))},{immediate:!0,deep:!0})},{setProps:t=>{var s;(s=p())==null||s.setProps(t)},openModal:()=>{var t;(t=p())==null||t.openModal()},closeModal:()=>{var t;(t=p())==null||t.closeModal()},setSubLoading:t=>{var s;(s=p())==null||s.setSubLoading(t)}}]}const he=[{field:"name",component:"NInput",label:"\u59D3\u540D",labelMessage:"\u8FD9\u662F\u4E00\u4E2A\u63D0\u793A",giProps:{span:1},componentProps:{placeholder:"\u8BF7\u8F93\u5165\u59D3\u540D",onInput:e=>{console.log(e)}},rules:[{required:!0,message:"\u8BF7\u8F93\u5165\u59D3\u540D",trigger:["blur"]}]},{field:"mobile",component:"NInputNumber",label:"\u624B\u673A",componentProps:{placeholder:"\u8BF7\u8F93\u5165\u624B\u673A\u53F7\u7801",showButton:!1,onInput:e=>{console.log(e)}}},{field:"type",component:"NSelect",label:"\u7C7B\u578B",giProps:{},componentProps:{placeholder:"\u8BF7\u9009\u62E9\u7C7B\u578B",options:[{label:"\u8212\u9002\u6027",value:1},{label:"\u7ECF\u6D4E\u6027",value:2}],onUpdateValue:e=>{console.log(e)}}},{field:"makeDate",component:"NDatePicker",label:"\u9884\u7EA6\u65F6\u95F4",giProps:{},defaultValue:118313526e4,componentProps:{type:"date",clearable:!0,onUpdateValue:e=>{console.log(e)}}},{field:"makeTime",component:"NTimePicker",label:"\u505C\u7559\u65F6\u95F4",giProps:{},componentProps:{clearable:!0,onUpdateValue:e=>{console.log(e)}}},{field:"makeProject",component:"NCheckbox",label:"\u9884\u7EA6\u9879\u76EE",giProps:{},componentProps:{placeholder:"\u8BF7\u9009\u62E9\u9884\u7EA6\u9879\u76EE",options:[{label:"\u79CD\u7259",value:1},{label:"\u8865\u7259",value:2},{label:"\u6839\u7BA1",value:3}],onUpdateChecked:e=>{console.log(e)}}},{field:"makeSource",component:"NRadioGroup",label:"\u6765\u6E90",giProps:{},componentProps:{options:[{label:"\u7F51\u4E0A",value:1},{label:"\u95E8\u5E97",value:2}],onUpdateChecked:e=>{console.log(e)}}},{field:"status",label:"\u72B6\u6001",giProps:{},slot:"statusSlot"}],De=V({components:{basicModal:H,BasicForm:W},setup(){const e=v(null),u=ce(),[o,{openModal:p,closeModal:r,setSubLoading:f}]=I({title:"\u65B0\u589E\u9884\u7EA6"}),[t,{openModal:s,closeModal:l,setSubLoading:m}]=I({title:"\u786E\u8BA4\u5BF9\u8BDD\u6846",showIcon:!0,type:"warning",closable:!1,maskClosable:!0}),[_,{submit:d}]=Ce({gridProps:{cols:1},collapsedRows:3,labelWidth:120,layout:"horizontal",submitButtonText:"\u63D0\u4EA4\u9884\u7EA6",showActionButtonGroup:!1,schemas:he}),F=ie({formValue:{name:"\u5C0F\u9A6C\u54E5"}});function g(){return w(this,null,function*(){const n=yield d();n?(r(),console.log("formRes",n),u.success("\u63D0\u4EA4\u6210\u529F")):(u.error("\u9A8C\u8BC1\u5931\u8D25\uFF0C\u8BF7\u586B\u5199\u5B8C\u6574\u4FE1\u606F"),f(!1))})}function b(){l(),m(!1)}function C(){s()}function h(){p()}function D(n){console.log(n)}return P(B({},re(F)),{modalRef:e,register:_,modalRegister:o,lightModalRegister:t,handleReset:D,showModal:h,okModal:g,lightOkModal:b,showLightModal:C})}});const Me={class:"n-layout-page-header"},ye=k("br",null,null,-1),ve=k("p",{class:"text-gray-500",style:{"padding-left":"35px"}},"\u4E00\u4E9B\u5BF9\u8BDD\u6846\u5185\u5BB9",-1);function Ae(e,u,o,p,r,f){const t=fe,s=me,l=Fe,m=Y,_=X,d=_e,F=W,g=H;return U(),pe("div",null,[k("div",Me,[a(t,{bordered:!1,title:"\u6A21\u6001\u6846"},{default:c(()=>[E(" \u6A21\u6001\u6846\uFF0C\u7528\u4E8E\u5411\u7528\u6237\u6536\u96C6\u6216\u5C55\u793A\u4FE1\u606F\uFF0CModal \u91C7\u7528 Dialog \u9884\u8BBE\uFF0C\u6269\u5C55\u62D6\u62FD\u6548\u679C "),ye,E(" \u4EE5\u4E0B\u662F useModal \u65B9\u5F0F\uFF0Cref\u65B9\u5F0F\uFF0C\u4E5F\u652F\u6301\uFF0C\u4F7F\u7528\u65B9\u5F0F\u548C\u5176\u4ED6\u7EC4\u4EF6\u4E00\u81F4\uFF0C\u5982\uFF1AmodalRef.value.closeModal() ")]),_:1})]),a(t,{bordered:!1,class:"mt-4 proCard"},{default:c(()=>[a(s,{title:"Modal\u5D4C\u5957Form",type:"info"},{default:c(()=>[E(" \u4F7F\u7528 useModal \u8FDB\u884C\u5F39\u7A97\u5C55\u793A\u548C\u64CD\u4F5C\uFF0C\u5E76\u6F14\u793A\u4E86\u5728Modal\u5185\u548CForm\u7EC4\u4EF6\uFF0C\u7EC4\u5408\u4F7F\u7528\u65B9\u6CD5 ")]),_:1}),a(l),a(_,null,{default:c(()=>[a(m,{type:"primary",onClick:e.showModal},{default:c(()=>[E("\u6253\u5F00Modal\u5D4C\u5957Form\u4F8B\u5B50")]),_:1},8,["onClick"])]),_:1}),a(l),a(s,{title:"\u4E2A\u6027\u5316\u8F7B\u91CF\u7EA7",type:"info"},{default:c(()=>[E(" \u4F7F\u7528 useModal \u8FDB\u884C\u5F39\u7A97\u5C55\u793A\u548C\u64CD\u4F5C\uFF0C\u81EA\u5B9A\u4E49\u914D\u7F6E\uFF0C\u5B9E\u73B0\u8F7B\u91CF\u7EA7\u6548\u679C\uFF0C\u66F4\u591A\u914D\u7F6E\uFF0C\u8BF7\u53C2\u8003\u6587\u6863 ")]),_:1}),a(l),a(_,null,{default:c(()=>[a(m,{type:"primary",onClick:e.showLightModal},{default:c(()=>[E("\u8F7B\u91CF\u7EA7\u786E\u8BA4")]),_:1},8,["onClick"])]),_:1}),a(l),a(s,{title:"\u63D0\u793A",type:"info"},{default:c(()=>[E(" \u7EC4\u4EF6\u66B4\u9732\u4E86\uFF0CsetProps \u65B9\u6CD5\uFF0C\u7528\u4E8E\u4FEE\u6539\u7EC4\u4EF6\u5185\u90E8 Props\uFF0C\u6BD4\u5982\u6807\u9898\uFF0C\u7B49\uFF0C\u5177\u4F53\u53C2\u8003UI\u6846\u67B6\u6587\u6863\uFF0CDialogReactive Properties ")]),_:1})]),_:1}),a(g,{onRegister:e.modalRegister,ref:"modalRef",class:"basicModal",onOnOk:e.okModal},{default:c(()=>[a(F,{onRegister:e.register,onReset:e.handleReset,class:"basicForm"},{statusSlot:c(({model:b,field:C})=>[a(d,{value:b[C],"onUpdate:value":h=>b[C]=h},null,8,["value","onUpdate:value"])]),_:1},8,["onRegister","onReset"])]),_:1},8,["onRegister","onOnOk"]),a(g,{onRegister:e.lightModalRegister,class:"basicModalLight",ref:"modalRef",onOnOk:e.lightOkModal},{default:c(()=>[ve]),_:1},8,["onRegister","onOnOk"])])}const Ne=de(De,[["render",Ae]]);export{Ne as default};
