var a=(i,o,t)=>new Promise((r,m)=>{var l=n=>{try{s(t.next(n))}catch(c){m(c)}},e=n=>{try{s(t.throw(n))}catch(c){m(c)}},s=n=>n.done?r(n.value):Promise.resolve(n.value).then(l,e);s((t=t.apply(i,o)).next())});import{r as f,ed as d,h as u,gu as h,cE as w,gv as y,cP as g}from"./index.1bc0c441.js";function p(i){const o=f(null),t=f(!1);function r(){return a(this,null,function*(){const e=u(o);return e||console.error("The form instance has not been obtained, please make sure that the form has been rendered when performing the form operation!"),yield g(),e})}function m(e){d(()=>{o.value=null,t.value=null}),!(u(t)&&h()&&e===u(o))&&(o.value=e,t.value=!0,w(()=>i,()=>{i&&e.setProps(y(i))},{immediate:!0,deep:!0}))}return[m,{setProps:e=>a(this,null,function*(){yield(yield r()).setProps(e)}),resetFields:()=>a(this,null,function*(){r().then(e=>a(this,null,function*(){yield e.resetFields()}))}),clearValidate:e=>a(this,null,function*(){yield(yield r()).clearValidate(e)}),getFieldsValue:()=>{var e;return(e=u(o))==null?void 0:e.getFieldsValue()},setFieldsValue:e=>a(this,null,function*(){yield(yield r()).setFieldsValue(e)}),submit:()=>a(this,null,function*(){return(yield r()).submit()}),validate:e=>a(this,null,function*(){return(yield r()).validate(e)}),setLoading:e=>{t.value=e},setSchema:e=>a(this,null,function*(){(yield r()).setSchema(e)})}]}export{p as u};
