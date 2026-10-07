using System;
using System.Collections.Generic;
using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_AttachmentSave : ModelerRuleBiz<Attachment>
{
	private void CreateAttachment(IDbContext dbContext, Attachment attachment)
	{
		int num = attachment.ValueCollection.ValidatedValue("_ROW_INDEX", 0);
		attachment.Attachmentsysid = $"{attachment.Relationtype}_{attachment.Relationid}_{Guid.NewGuid().ToString()}_{++num}";
		DBTransactionCheck(ACTIVITY, 2, ATTACHMENT.UpsertAttachment(dbContext, RequestType.CREATE, new Attachment[1] { attachment }, null, saveHist: true));
		if (base.ReplyData.DATADIC == null)
		{
			base.ReplyData.DATADIC = new Dictionary<string, Dictionary<string, object>>();
		}
		if (!base.ReplyData.DATADIC.ContainsKey("ATTACHMENT"))
		{
			base.ReplyData.DATADIC["ATTACHMENT"] = new Dictionary<string, object>();
		}
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary["ATTACHMENTSYSID"] = attachment.Attachmentsysid;
		dictionary["ATTACHFILENAME"] = attachment.Attachfilename;
		dictionary["FILELENGTH"] = attachment.Filelength;
		base.ReplyData.DATADIC["ATTACHMENT"][num.ToString()] = dictionary;
	}

	public void DeleteAttachment(IDbContext dbContext, Dictionary<string, object> dic)
	{
		Attachment attachment = ConvertToEntityObject<Attachment>(dbContext, dic);
		SetCommonData(dbContext, attachment, ACTIVITY, RequestType.DELETE, base.RequestData.TID);
		DBTransactionCheck(ACTIVITY, 2, DeleteAttachment(dbContext, attachment));
	}

	private int DeleteAttachment(IDbContext dbContext, Attachment attachment)
	{
		return ATTACHMENT.UpsertAttachment(dbContext, RequestType.DELETE, new Attachment[1] { attachment }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Attachment attachment)
	{
		CreateAttachment(dbContext, attachment);
	}

	public override void DeleteAPI(IDbContext dbContext, Attachment attachment)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteAttachment(dbContext, attachment));
	}

	public override void UpdateAPI(IDbContext dbContext, Attachment attachment)
	{
	}
}
