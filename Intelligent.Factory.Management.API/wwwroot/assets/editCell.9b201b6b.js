var h=Object.defineProperty;var y=Object.getOwnPropertySymbols;var w=Object.prototype.hasOwnProperty,E=Object.prototype.propertyIsEnumerable;var _=(i,t,e)=>t in i?h(i,t,{enumerable:!0,configurable:!0,writable:!0,value:e}):i[t]=e,m=(i,t)=>{for(var e in t||(t={}))w.call(t,e)&&_(i,e,t[e]);if(y)for(var e of y(t))E.call(t,e)&&_(i,e,t[e]);return i};var f=(i,t,e)=>new Promise((l,r)=>{var s=o=>{try{n(e.next(o))}catch(a){r(a)}},d=o=>{try{n(e.throw(o))}catch(a){r(a)}},n=o=>o.done?l(o.value):Promise.resolve(o.value).then(s,d);n((e=e.apply(i,t)).next())});import{B as b}from"./TableAction.vue_vue_type_script_lang.45bb6f38.js";import{g}from"./list.ed0ca215.js";import{c0 as v,fT as T,d as x,r as B,b as D,o as N,c3 as R,w as p,i as k,h as C,j as M,l as A,ca as H}from"./index.ff5a668a.js";import"./vuedraggable.umd.d505abd4.js";import"./useDesignSetting.1ba28d32.js";import"./SettingOutlined.1dc92e20.js";import"./propTypes.54b06ce7.js";import"./FormOutlined.06bd75c8.js";import"./ReloadOutlined.9860cd6e.js";import"./componentSetting.e6bd74f7.js";import"./index.ae498cec.js";import"./DownOutlined.67d87310.js";const P=[{title:"id",key:"id",width:100},{title:"\u7F16\u7801",key:"no",width:100},{title:"\u540D\u79F0",key:"name",editComponent:"NInput",editRule:!0,edit:!0,width:200},{title:"\u5934\u50CF",key:"avatar",width:100,render(i){return v(T,{size:48,src:i.avatar})}},{title:"\u5730\u5740",key:"address",editComponent:"NSelect",editComponentProps:{options:[{label:"\u5E7F\u4E1C\u7701",value:1},{label:"\u6D59\u6C5F\u7701",value:2}]},edit:!0,width:200,ellipsis:!1},{title:"\u5F00\u59CB\u65E5\u671F",key:"beginTime",edit:!0,width:160,editComponent:"NDatePicker",editComponentProps:{type:"datetime",format:"yyyy-MM-dd HH:mm:ss",valueFormat:"yyyy-MM-dd HH:mm:ss"},ellipsis:!1},{title:"\u7ED3\u675F\u65E5\u671F",key:"endTime",width:160},{title:"\u521B\u5EFA\u65F6\u95F4",key:"date",width:160},{title:"\u505C\u7559\u65F6\u95F4",key:"time",width:80}],Q=x({__name:"editCell",setup(i){const t=B(),e=D({pageSize:5,name:"xiaoMa"});function l({column:o,value:a,record:u}){o.key==="id"&&(u.editValueRefs.name4.value=`${a}`),console.log(o,a,u)}const r=o=>f(this,null,function*(){return yield g(m(m({},e),o))});function s(o){console.log(o)}function d(){console.log(t.value),t.value.reload()}function n({record:o,index:a,key:u,value:c}){console.log(c)}return(o,a)=>{const u=A,c=H;return N(),R(c,{bordered:!1,class:"proCard"},{default:p(()=>[k(C(b),{title:"\u8868\u683C\u5217\u8868",titleTooltip:"\u8FD9\u662F\u4E00\u4E2A\u63D0\u793A",columns:C(P),request:r,"row-key":F=>F.id,ref_key:"actionRef",ref:t,onEditEnd:n,onEditChange:l,"onUpdate:checkedRowKeys":s,"scroll-x":1360},{toolbar:p(()=>[k(u,{type:"primary",onClick:d},{default:p(()=>[M("\u5237\u65B0\u6570\u636E")]),_:1})]),_:1},8,["columns","row-key"])]),_:1})}}});export{Q as default};
