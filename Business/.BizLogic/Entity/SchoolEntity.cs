﻿#region RDIFramework.NET-generated
//------------------------------------------------------------------------------
//	RDIFramework.NET，是基于.NET的快速信息化系统开发、整合框架，给用户和开发者最佳的.Net框架部署方案。
//	RDIFramework.NET平台包含基础公共类库、强大的权限控制、模块分配、数据字典、自动升级、各商业级控件库、工作流平台、代码生成器、开发辅助
//工具等，应用系统的各个业务功能子系统，在系统体系结构设计的过程中被设计成各个原子功能模块，各个子功能模块按照业务功能组织成单独的程序集文
//件，各子系统开发完成后，由RDIFramework.NET平台进行统一的集成部署。
//
// 框架官网：http://www.rdiframework.net/
// 框架博客：http://blog.rdiframework.net/
// 版权所有：海南国思软件科技有限公司
// 交流QQ：406590790 
// 邮件交流：406590790@qq.com
// 其他博客：
//      http://www.cnblogs.com/huyong 
//      http://blog.csdn.net/chinahuyong
//------------------------------------------------------------------------------
// <auto-generated>
//	此代码由RDIFramework.NET平台代码生成工具自动生成。
//	运行时版本:4.0.30319.1
//
//	对此文件的更改可能会导致不正确的行为，并且如果
//	重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace .BizLogic
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// SchoolEntity
    /// 
    /// 
    /// 修改纪录
    /// 
    /// 2020-03-31 版本：3.6 yoky 创建主键。
    /// 
    /// 版本：3.6
    /// 
    /// <author>
    /// <name>yoky</name>
    /// <date>2020-03-31</date>
    /// </author>
    /// </summary>
    public partial class SchoolEntity : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key] 
        [ScaffoldColumn(false)] 
        [DataMember] 
        public String Id { get; set; } 

        /// <summary>
        /// NAME
        /// </summary>
        [StringLength(50, ErrorMessage = "Name不能超过50个字符")] 
        [Display(Name = "Name")] 
        [DataType(DataType.Text)]
        [DataMember] 
        public String Name { get; set; } 

        /// <summary>
        /// ADDRESS
        /// </summary>
        [StringLength(200, ErrorMessage = "Address不能超过200个字符")] 
        [Display(Name = "Address")] 
        [DataType(DataType.Text)]
        [DataMember] 
        public String Address { get; set; } 

        /// <summary>
        /// TEL
        /// </summary>
        [StringLength(255, ErrorMessage = "Tel不能超过255个字符")] 
        [Display(Name = "Tel")] 
        [DataType(DataType.Text)]
        [DataMember] 
        public String Tel { get; set; } 

        /// <summary>
        /// 构造函数
        /// </summary>
        public SchoolEntity()
        {
        }


        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        protected override BaseEntity GetFrom(IDataRow dataRow)
        {
            this.Id = BusinessLogic.ConvertToString(dataRow[SchoolTable.FieldId]);
            this.Name = BusinessLogic.ConvertToString(dataRow[SchoolTable.FieldName]);
            this.Address = BusinessLogic.ConvertToString(dataRow[SchoolTable.FieldAddress]);
            this.Tel = BusinessLogic.ConvertToString(dataRow[SchoolTable.FieldTel]);
            return this;
        }
    }
}
