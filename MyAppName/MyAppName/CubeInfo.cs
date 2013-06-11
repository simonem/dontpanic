using System;
using Sifteo;
using Newtonsoft.Json;

namespace CubeInfoContainer
{
	public class CubeInfo
	{
		public string role;
		public int nodeid;

		public CubeInfo(){

		}

		public CubeInfo (string role, int nodeid)
		{
			this.role = role;
			this.nodeid = nodeid;
		}

		public string getRole(){
			return role;
		}
		public int getNodeid(){
			return nodeid;
		}
	}
}

