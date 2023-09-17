# Intelligent-Factory-Manage-Service

## Client Domain
### create client request dto
| 字段 | 类型    | 备注  | 是否在table显示 | 是否form提交|
|----|-------| ----   |-------|---------|
| ClientType | int   | 客户类型 |       | 是 |
| Name | string | 客户名称 |       | 是      |
| Street | string | 街道名称 |       | 是      |
| City | string | 城市名称 |       | 是      |
| Province | string | 省份名称 |       | 是      |
| ZipCode | string | 邮政编码 |       | 是      |
| ClientAgent | Entity | 代理人 |       | 是      |
| TFN | string | 税号   |       | 是      |
| BankTitle | string | 银行抬头 |       | 是       |
| BankAccount | string | 银行账号 |       | 是       |
| BillingTelephone | string | 开票电话  |       | 是 |
| ContactNumber | string | 联系电话 |       | 是 |
| Email | string | 邮箱  |       | 是   |
| Fax | string | 传真  |       | 是 |
### create client response ：id （int）

### get client ：
#### FromQuery(Page)
| 字段        | 类型    | 备注   | 是否form提交      |
|:----------|:------|:-----|:--------------|
| PageSize  | int   | 页面大小 | 需要            | 
| PageIndex | int   | 页面索引 | 需要            | 
| Total | int   | 页面索引 | 不需要           |
#### Response
| 字段               | 类型    | 备注  | 是否在table显示 | 是否form提交|
|------------------|-------| ----   |-------|---------|
| Id               | int   | 客户类型 |       | 是 |
| ClientType       | int   | 客户类型 |       | 是 |
| Name             | string | 客户名称 |       | 是      |
| Street           | string | 街道名称 |       | 是      |
| City             | string | 城市名称 |       | 是      |
| Province         | string | 省份名称 |       | 是      |
| ZipCode          | string | 邮政编码 |       | 是      |
| ClientAgent      | Entity | 代理人 |       | 是      |
| TFN              | string | 税号   |       | 是      |
| BankTitle        | string | 银行抬头 |       | 是       |
| BankAccount      | string | 银行账号 |       | 是       |
| BillingTelephone | string | 开票电话  |       | 是 |
| ContactNumber    | string | 联系电话 |       | 是 |
| Email            | string | 邮箱  |       | 是   |
| Fax              | string | 传真  |       | 是 |
##### ClientAgent
| 字段          | 类型     | 备注    | 是否在table显示 | 是否form提交 |
|-------------|--------|-------|----------|----------|
| Name        | string | 代理人姓名 | 是        | 是        |
| PhoneNumber | string | 代理人电话 | 是        | 是        |
