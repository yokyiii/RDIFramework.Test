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
using System.Data;

namespace RDIFramework.Test
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// SchoolManager
    /// 
    /// 
    /// 修改纪录
    /// 
    /// 2020-04-04 版本：3.6 yoky 创建主键。
    /// 
    /// 版本：3.6
    /// 
    /// <author>
    /// <name>yoky</name>
    /// <date>2020-04-04</date>
    /// </author>
    /// </summary>
    public partial class SchoolManager : DbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SchoolManager()
        {
            base.CurrentTableName = SchoolTable.TableName;
            base.PrimaryKey = "Id";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public SchoolManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public SchoolManager(IDbProvider dbProvider): this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public SchoolManager(UserInfo userInfo) : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public SchoolManager(IDbProvider dbProvider, UserInfo userInfo) : this(dbProvider)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public SchoolManager(IDbProvider dbProvider, UserInfo userInfo, string tableName) : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="schoolEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(SchoolEntity schoolEntity)
        {
            return this.AddEntity(schoolEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="schoolEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(SchoolEntity schoolEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(schoolEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="schoolEntity">实体</param>
        public int Update(SchoolEntity schoolEntity)
        {
            return this.UpdateEntity(schoolEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public SchoolEntity GetEntity(string id)
        {
            return BaseEntity.Create<SchoolEntity>(this.GetDT(SchoolTable.FieldId, id));
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="schoolEntity">实体</param>
        public string AddEntity(SchoolEntity schoolEntity)
        {
            string sequence = string.Empty;
            this.Identity = false; 
            if (schoolEntity.Id != null)
            {
                sequence = schoolEntity.Id.ToString();
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, SchoolTable.FieldId);
            if (!this.Identity) 
            {
                if (string.IsNullOrEmpty(schoolEntity.Id)) 
                { 
                    sequence = BusinessLogic.NewGuid(); 
                    schoolEntity.Id = sequence ;
                }
                sqlBuilder.SetValue(SchoolTable.FieldId, schoolEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(SchoolTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(SchoolTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(schoolEntity.Id))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            schoolEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(SchoolTable.FieldId, schoolEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, schoolEntity);
            if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.SqlServer || DBProvider.CurrentDbType == CurrentDbType.Access))
            {
                sequence = sqlBuilder.EndInsert().ToString();
            }
            else
            {
                sqlBuilder.EndInsert();
            }
            return sequence;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="schoolEntity">实体</param>
        public int UpdateEntity(SchoolEntity schoolEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, schoolEntity);
            sqlBuilder.SetWhere(SchoolTable.FieldId, schoolEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder">sql语句生成器</param>
        /// <param name="schoolEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, SchoolEntity schoolEntity)
        {
            sqlBuilder.SetValue(SchoolTable.FieldName, schoolEntity.NAME);
            sqlBuilder.SetValue(SchoolTable.FieldAddress, schoolEntity.Address);
            sqlBuilder.SetValue(SchoolTable.FieldTel, schoolEntity.Tel);
            sqlBuilder.SetValue(SchoolTable.FieldDelectmark, schoolEntity.Delectmark);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(SchoolTable.FieldId, id));
        }
    }
}