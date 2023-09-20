using Intelligent.Factory.Management.Domain.AggregatesModel.ProductAggregate;

namespace Intelligent.Factory.Management.API.DTOs;

public record ProductItemDto
{
    /// <summary>
    /// 产品类型Id
    /// </summary>
    public ProductType ProductType { get; set; }

    /// <summary>
    /// 产品明细名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 规格型号
    /// </summary>
    public string Specifications { get; set; }

    /// <summary>
    /// 数量
    /// </summary>
    public int Amount { get; set; }

    /// <summary>
    /// 单价
    /// </summary>
    public int UnitPrice { get; set; }

    /// <summary>
    /// 单位
    /// </summary>
    public string Unit { get; set; }

    /// <summary>
    /// 材料型号
    /// </summary>
    public string Material { get; set; }

    /// <summary>
    /// 技术要求
    /// </summary>
    public string TechnicalRequirements { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string Remark { get; set; }
}