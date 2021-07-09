using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UTM_App
{
	class fireBaseConnect
	{
		IFirebaseConfig fcon = new FirebaseConfig()
		{
			AuthSecret = "ByiecarDXxxLsznLQSB4Vv5MQxSiSPVx6q11iNTV",
			BasePath = "https://iotvoice-9d398-default-rtdb.firebaseio.com/"

		};
		static IFirebaseClient client;

		public fireBaseConnect()
		{
			try {
				client = new FireSharp.FirebaseClient(fcon);
			}
			catch
			{
				Console.WriteLine("no network");
			}
		}

		public static void writeToFirebase(String msg)
		{
			try
			{
				client.Set("utm", msg);
			}
			catch
			{
				Console.WriteLine("no network");
			}
			
		}

		public static String readFromFirebase(String location)
		{
			String data = "";
			try
			{
				FirebaseResponse response = client.Get(location);
				data = response.ResultAs<String>();	
			}
			catch
			{
				Console.WriteLine("no network");
			}


			return data;
			
		}

	}
}
