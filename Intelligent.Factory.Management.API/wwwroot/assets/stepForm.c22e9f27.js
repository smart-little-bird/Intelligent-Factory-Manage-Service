import{_ as f}from"./Step1.vue_vue_type_script_setup_true_lang.c51967b0.js";import{_ as v}from"./Step2.vue_vue_type_script_setup_true_lang.9782636a.js";import x from"./Step3.a256c5db.js";import{n as g,r as u,o as n,c as y,a as S,i as t,w as s,j as h,c3 as a,cR as _,ca as k,gA as N,gB as b,c6 as B}from"./index.1bc0c441.js";const F={class:"n-layout-page-header"},V={__name:"stepForm",setup(C){const e=u(1),i=u("process");function c(){e.value<3&&(e.value+=1)}function r(){e.value>1&&(e.value-=1)}function l(){e.value=1}return(j,w)=>{const p=k,o=N,m=b,d=B;return n(),y("div",null,[S("div",F,[t(p,{bordered:!1,title:"\u5206\u6B65\u8868\u5355"},{default:s(()=>[h(" \u5C06\u4E00\u4E2A\u5197\u957F\u6216\u7528\u6237\u4E0D\u719F\u6089\u7684\u8868\u5355\u4EFB\u52A1\u5206\u6210\u591A\u4E2A\u6B65\u9AA4\uFF0C\u6307\u5BFC\u7528\u6237\u5B8C\u6210\u3002 ")]),_:1})]),t(p,{bordered:!1,class:"mt-4 proCard"},{default:s(()=>[t(d,{vertical:"",class:"steps",justify:"center"},{default:s(()=>[t(m,{current:e.value,status:i.value},{default:s(()=>[t(o,{title:"\u586B\u5199\u8F6C\u8D26\u4FE1\u606F",description:"\u786E\u4FDD\u586B\u5199\u6B63\u786E"}),t(o,{title:"\u786E\u8BA4\u8F6C\u8D26\u4FE1\u606F",description:"\u786E\u8BA4\u8F6C\u8D26\u4FE1\u606F"}),t(o,{title:"\u5B8C\u6210\u8F6C\u8D26",description:"\u606D\u559C\u60A8\uFF0C\u8F6C\u8D26\u6210\u529F"})]),_:1},8,["current","status"]),e.value===1?(n(),a(f,{key:0,onNextStep:c})):_("",!0),e.value===2?(n(),a(v,{key:1,onNextStep:c,onPrevStep:r})):_("",!0),e.value===3?(n(),a(x,{key:2,onPrevStep:r,onFinish:l})):_("",!0)]),_:1})]),_:1})])}}},E=g(V,[["__scopeId","data-v-6b93fa53"]]);export{E as default};
