_# Intelligent-Factory-Manage-Service

## Client Domain
### create client request dto
| 字段               | 类型    | 备注  | 是否在table显示 | 是否form提交|
|------------------|-------| ----   |-------|---------|
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
### create client response ：id （int）

### get client ：
#### FromQuery(Page)
| 字段        | 类型    | 备注   | 是否form提交      |
|:----------|:------|:-----|:--------------|
| PageSize  | int   | 页面大小 | 需要            | 
| PageIndex | int   | 页面索引 | 需要            | 
| Total     | int   | 页面索引 | 不需要           |
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

## Product Domain

### create Product request dto
| 字段              | 类型       | 备注   | 是否在table显示 | 是否form提交 |
|-----------------|----------|------|-----------|----------|
| Description     | string   | 产品描述 |           |  是       |
| EntryCriteria   | string   | 入级   |           | 是        |
| ProductItemDtos | [Entity] | 产品明细 |           | 是        |

### create ProductItemDtos request dto
| 字段                    | 类型     | 备注   | 是否在table显示 | 是否form提交 |
|-----------------------|--------|------|-----------|----------|
| ProductType           | int    | 产品明细名称 |           |  是       |
| Name                  | string | 产品明细名称 |           |  是       |
| Specifications        | string | 规格型号   |           | 是        |
| Amount                | int    | 数量 |           | 是        |
| UnitPrice             | int    | 单价   |           | 是        |
| Unit                  | string | 单位 |           | 是        |
| Material              | string | 材料型号 |           | 是        |
| TechnicalRequirements | string    | 技术要求   |           | 是        |
| Remark                | string | 备注 |           | 是        |

### get ProductListPageDto
| 字段              | 类型               | 备注      | 是否在table显示 | 是否form提交 |
|-----------------|------------------|---------|-----------|----------|
| ProductListDtos | [ProductListDto] | 产品明细类   |   是       |  是       |
| Page            | Page             | 页码类     |   是       |  是       |
###  ProductListDto
| 字段               | 类型                | 备注            | 是否在table显示 | 是否form提交|
|------------------|-------------------|---------------|------------|------------|
| Id               | int               | Id            |            | 是        |
| Description      | string            | 产品描述          |            | 是      |
| EntryCriteria    | string            | 入级描述          |            | 是      |
| ProductItemDtos  | [ProductItemDto]  | 产品明细对象集合      |            | 是    |
####  ProductItemDto 
| 字段                    | 类型     | 备注     | 是否在table显示 | 是否form提交|
|-----------------------|--------|--------|------------|------------|
| Id                    | int    | Id     |            | 是        |
| ProductType           | enum   | 产品类型   |            | 是      |
| Name                  | string | 产品明细名称 |            | 是      |
| Specifications        | string | 规格型号   |            | 是    |
| Unit                  | string | 单位     |            | 是      |
| Amount                | int    | 数量     |            | 是      |
| UnitPrice             | int    | 单价     |            | 是      |
| Material              | string | 材料     |            | 是      |
| TechnicalRequirements | string | 技术要求   |            | 是    |
| Remark                | string | 备注     |            | 是    |
| TotalPrice            | int    | 总价     |            | 是      |

## Contract Core Domain
### Create Contract Request DTO
| 字段                   | 类型                      | 备注         | 是否在table显示 | 是否form提交|
|----------------------|-------------------------|------------|------------|------------|
| ClientId             | int                     | 客户Id       |            | 是        |
| ClientName           | string                  | 客户名称       |            | 是        |
| Phone                | string                  | 客户电话       |            | 是        |
| BankAccount          | int                     | Id         |            | 是        |
| Street               | string                  | 客户地址街道     |            | 是        |
| City                 | string                  | 客户地址城市     |            | 是        |
| Province             | string                  | 客户地址省份     |            | 是        |
| IsCombineFax         | bool                    | 是否含税       |            | 是        |
| ContractItems        | [ContractItemDto]       | 合同明细集合     |            | 是        |
| ContractPayMethod    | ContractPayMethod       | 付款方式       |            | 是        |
| ContractShippingInfo | ContractShippingInfoDto | 合同配送信息     |            | 是        |
#### ContractItemDto DTO
| 字段                 | 类型        | 备注           | 是否在table显示 | 是否form提交    |
|---------------------|-----------|--------------|------------|-------------|
| ProductName         | string    | 产品名称       |            | 是           |
| Unit                | string    | 单位           |            | 是           |
| Amount              | int       | 数量           |            | 是           |
| UnitPrice           | int       | 单价           |            | 是           |
| Material            | string    | 材料           |            | 是           |
| IsIndependent       | bool      | 是否独立产品     |            | 是         |
| ProductId            | int       | 产品ID         |            | 是           |
#### ContractPayMethod DTO
| 字段                 | 类型                | 备注         | 是否在table显示 | 是否form提交 |
|---------------------|-------------------|------------|-----------|-------------|
| PaymentType         | PaymentType[Enum] | 支付方式       |         | 是          |
| PayPercents         | List<int>?        | 支付百分比集合    |         | 是          |、
#### ContractShippingInfoDto DTO
| 字段                 | 类型      | 备注       | 是否在table显示 | 是否form提交 |
|---------------------|----------|------------|------------|-------------|
| ShipDateTime        | DateTime | 交货日期      |            | 是          |
| ShipType            | string   | 交货方式       |            | 是          |
| LogisticsUndertaker | string   | 物流承担方      |            | 是          |
### getList ContractListPageDto 
| 字段               | 类型                           | 备注         | 是否在table显示 | 是否form提交    |
|------------------|------------------------------|------------|------------|-------------|
| ContractListDtos | IEnumerable<ContractListDto> | 合同明细集合     |            | 是       |
| Page             | PageDto                      | 页码对象       |            | 是        |
####  ClientListDto 
| 字段                  | 类型         | 备注         | 是否在table显示 | 是否form提交 |
|---------------------|------------|------------|------------|-------------|
| ContractId          | int        | 合同ID       |            | 是          |
| ContractNo          | string     | 合同编号       |            | 是          |
| ClientName          | string     | 客户名称       |            | 是          |
| ShipDateTime        | DateTime   | 交货日期       |            | 是          |
| ShipType            | string     | 货运方式       |            | 是          |
| TotalPrice          | int        | 总价         |            | 是          |
