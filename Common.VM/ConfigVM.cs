using System;
using System.Collections.Generic;

namespace Common.VM
{
    public class ConfigVM
    {
		public List<UrlConfig> UrlConfigList { get; set; } = new List<UrlConfig>();
	}
	public class UrlConfig
	{
		public string UrlTransaction { get; set; }
		public string TableTransaction { get; set; }
		public string TableName { get; set; }
		public bool IsTransaction { get; set; }
	}
}
