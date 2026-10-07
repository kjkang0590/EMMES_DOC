using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CIM.MES.API.CDS;
using CIM.MES.API.POS;
using CIM.MES.Common;
using CIM.MES.Common.Data;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Framework.Rule;
using CIM.MES.Logging;
using Newtonsoft.Json;

namespace THiRAMES.Service.Modeler;

public abstract class ModelerRuleBiz<TEntity> : MesRuleBase where TEntity : EntityTemplate
{
	private MessageData _requestData;

	private MessageData _replayData;

	public virtual string ACTIVITY => RequestData.COMMAND;

	public MessageData RequestData => _requestData;

	public MessageData ReplyData => _replayData;

	public Hashtable STOREDQUERY => RequestData.STOREDQUERY;

	public Hashtable HASHTABLE => RequestData.HASHTABLE;

	public List<Dictionary<string, object>> WEBDATA => RequestData.WEBDATA;

	public string SITEID => RequestData.SITEID;

	public string USERID => RequestData.USERID;

	public override MessageData DoWork(IDbContext dbContext, MessageData requestData)
	{
		MesLogger.InfoTid("RULE", requestData.TID, "START : " + base.Name);
		_requestData = requestData;
		_replayData = CreateDefaultReplyData(_requestData);
		MessageValidation(dbContext);
		if (WEBDATA.Count > 0)
		{
			Process(dbContext);
		}
		MesLogger.InfoTid("RULE", requestData.TID, "END : " + base.Name);
		return _replayData;
	}

	public virtual void MessageValidation(IDbContext dbContext)
	{
		WEBDATA.WebdataMessage("_ROW_STATE", "SITEID");
	}

	public virtual void Process(IDbContext dbContext)
	{
		ConvertWebdata(dbContext);
	}

	public abstract void CreateAPI(IDbContext dbContext, TEntity entity);

	public abstract void UpdateAPI(IDbContext dbContext, TEntity entity);

	public abstract void DeleteAPI(IDbContext dbContext, TEntity entity);

	public virtual void RealDeleteAPI(IDbContext dbContext, TEntity entity)
	{
	}

	public T Resolve<T>(IDbContext dbContext)
	{
		return dbContext.Resolve<T>();
	}

	public void SetCommonData(IDbContext dbContext, EntityTemplate entityTemplate, string activity, RequestType requestType, string comments = "")
	{
		if (requestType == RequestType.CREATE)
		{
			entityTemplate.Prevactivity = entityTemplate.Activity;
			entityTemplate.Prevcustomactivity = entityTemplate.Customactivity;
			entityTemplate.Creator = USERID;
			entityTemplate.Createtime = dbContext.Now;
		}
		if (!string.IsNullOrEmpty(comments))
		{
			entityTemplate.Comments = comments;
		}
		entityTemplate.Modifier = USERID;
		entityTemplate.Activity = activity;
		entityTemplate.Customactivity = activity;
		entityTemplate.Modifytime = dbContext.Now;
		entityTemplate.Tid = dbContext.Tid;
	}

	public void SetCommonData(IDbContext dbContext, EntityTemplate entityTemplate, EntityTemplate targetentity, RequestType requestType)
	{
		if (requestType == RequestType.CREATE)
		{
			targetentity.Prevactivity = entityTemplate.Activity;
			targetentity.Prevcustomactivity = entityTemplate.Customactivity;
			targetentity.Creator = dbContext.Userid;
			targetentity.Createtime = dbContext.Now;
		}
		if (!string.IsNullOrEmpty(entityTemplate.Description))
		{
			targetentity.Comments = entityTemplate.Description;
		}
		if (!string.IsNullOrEmpty(entityTemplate.Comments))
		{
			targetentity.Comments = entityTemplate.Comments;
		}
		targetentity.Modifier = dbContext.Userid;
		targetentity.Activity = dbContext.Activity;
		targetentity.Customactivity = dbContext.Activity;
		targetentity.Modifytime = dbContext.Now;
		targetentity.Tid = dbContext.Tid;
	}

	public string[] GenerateIdPattern(IDbContext dbContext, string idPattern, int count = 1, params string[] parameters)
	{
		using IDbContext dbContext2 = dbContext.CreateDbContext(dbContext.DatabaseInfo.Name);
		try
		{
			Idpattern idPattern2 = IDPATTERN.GetIdPattern(dbContext2, idPattern, SITEID);
			if (idPattern2 == null)
			{
				throw new MesMultiLanguageException(ModelerErrorCode.E_MES_MODELER_005, idPattern);
			}
			IList<string> source = IDINDEX.GenerateIdByPattern(dbContext2, idPattern2.Idpatternid, SITEID, null, count, commit: true, parameters);
			dbContext2.SaveChanges();
			dbContext2.CommitTransaction();
			return source.ToArray();
		}
		catch (MesMultiLanguageException ex)
		{
			throw ex;
		}
		catch (Exception)
		{
			throw;
		}
	}

	private void ConvertWebdata(IDbContext dbContext)
	{
		int num = -1;
		TEntity[] webdata = GetWebdata(dbContext);
		foreach (TEntity val in webdata)
		{
			val.SetValue("_ROW_INDEX", num++);
			switch (val.ValidatedValue("_ROW_STATE"))
			{
			case "A":
				SetCommonData(dbContext, val, ACTIVITY, RequestType.CREATE, RequestData.TID);
				CreateAPI(dbContext, val);
				break;
			case "U":
				SetCommonData(dbContext, val, ACTIVITY, RequestType.UPDATE, RequestData.TID);
				UpdateAPI(dbContext, val);
				break;
			case "D":
				SetCommonData(dbContext, val, ACTIVITY, RequestType.DELETE, RequestData.TID);
				DeleteAPI(dbContext, val);
				break;
			case "RD":
				SetCommonData(dbContext, val, ACTIVITY, RequestType.REALDELETE, RequestData.TID);
				RealDeleteAPI(dbContext, val);
				break;
			default:
				throw new MesMultiLanguageException("E_MES_MODELER_003", "_ROW_STATE", val.ValueCollection["_ROW_STATE"].ToString());
			}
		}
	}

	protected TEntity[] GetWebdata(IDbContext dbContext)
	{
		List<TEntity> list = new List<TEntity>();
		foreach (Dictionary<string, object> wEBDATum in WEBDATA)
		{
			TEntity item = ConvertToEntityObject<TEntity>(dbContext, wEBDATum);
			list.Add(item);
		}
		return list.ToArray();
	}

	protected T[] GetWebdataDATALIST<T>(int webdataIndex, string key, Action<T[]> action = null) where T : EntityTemplate
	{
		if (WEBDATA.Count < 1)
		{
			return null;
		}
		if (!WEBDATA[webdataIndex].ContainsKey("DATALIST"))
		{
			return null;
		}
		Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(WEBDATA[webdataIndex]["DATALIST"]?.ToString());
		if (dictionary == null)
		{
			return null;
		}
		if (!dictionary.ContainsKey(key))
		{
			return null;
		}
		T[] array = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(dictionary[key]?.ToString()).ConvertToEntityObject<T>();
		action?.Invoke(array);
		return array;
	}

	protected T ConvertToEntityObject<T>(IDbContext dbContext, Dictionary<string, object> dic) where T : EntityTemplate
	{
		T val = dbContext.ConvertToEntityObject<T>(dic);
		StringBuilder stringBuilder = new StringBuilder();
		foreach (string key in val.KeyCollection.Keys)
		{
			if (string.IsNullOrEmpty(val.KeyCollection.ValidatedValue(key)))
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(", " + key + ":" + val.KeyCollection.ValidatedValue(key));
				}
				else
				{
					stringBuilder.Append(key + ":" + val.KeyCollection.ValidatedValue(key));
				}
			}
		}
		if (stringBuilder.Length > 0)
		{
			throw new EntityNotFoundException(typeof(T), stringBuilder.ToString());
		}
		return val;
	}

	protected void DBTransactionCheck(string bizRule, int checkCount, int count)
	{
		if (count != checkCount)
		{
			throw new MesMultiLanguageException(ModelerErrorCode.E_MES_TRANSACTIONCHECK_001, bizRule, count.ToString(), checkCount.ToString());
		}
	}

	protected DataSet ExecuteQueryId(IDbContext dbContext, string queryid, params MesParameter[] parameters)
	{
		return Resolve<IQueryManager>(dbContext).ExecuteDataSet(dbContext, queryid, parameters.ToList());
	}
}
