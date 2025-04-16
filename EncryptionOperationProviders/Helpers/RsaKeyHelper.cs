using System.Numerics;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace EncryptionOperationProviders.Helpers;

public class RsaKeyHelper
{
	public static async Task<bool> IsRsaKeyValidAsync(string key)
	{
		string cleanedPrivateKey = CleanXmlKey(key);
		try
		{
			await FromXmlStringAsync(cleanedPrivateKey);
		}
		catch
		{
			return false;
		}
		return true;
	}

	public static async Task<RSAParameters> FromXmlStringAsync(string xmlKey)
	{
		return await Task.Run(() => FromXmlString(xmlKey));
	}
	
	public static RSAParameters FromXmlString(string xmlKey)
	{
		string cleanedPrivateKey = CleanXmlKey(xmlKey);
		
		var rsaParameters = new RSAParameters();
		var xml = XElement.Parse(cleanedPrivateKey);

		rsaParameters.Modulus = GetElementValue(xml, "Modulus");
		rsaParameters.Exponent = GetElementValue(xml, "Exponent");

		if (xml.Element("D") != null) // Check if it's a private key
		{
			rsaParameters.D = GetElementValue(xml, "D");
			rsaParameters.P = GetElementValue(xml, "P");
			rsaParameters.Q = GetElementValue(xml, "Q");
			rsaParameters.DP = GetElementValue(xml, "DP");
			rsaParameters.DQ = GetElementValue(xml, "DQ");
			rsaParameters.InverseQ = GetElementValue(xml, "InverseQ");
		}
		return rsaParameters;
	}
	public static string ToXmlString(RSAParameters rsaParameters, bool includePrivateParameters)
	{
		var xml = new XElement("RSAKeyValue",
			new XElement("Modulus", Convert.ToBase64String(rsaParameters.Modulus)),
			new XElement("Exponent", Convert.ToBase64String(rsaParameters.Exponent))
		);

		if (includePrivateParameters)
		{
			xml.Add(
				new XElement("P", Convert.ToBase64String(rsaParameters.P)),
				new XElement("Q", Convert.ToBase64String(rsaParameters.Q)),
				new XElement("DP", Convert.ToBase64String(rsaParameters.DP)),
				new XElement("DQ", Convert.ToBase64String(rsaParameters.DQ)),
				new XElement("InverseQ", Convert.ToBase64String(rsaParameters.InverseQ)),
				new XElement("D", Convert.ToBase64String(rsaParameters.D))
			);
		}

		return xml.ToString();
	}
	private static byte[] GetElementValue(XElement xml, string name)
	{
		var element = xml.Element(name);
		return element != null ? Convert.FromBase64String(element.Value) : null;
	}
	public static string CleanXmlKey(string xmlKey)
	{
		return xmlKey.Replace("\r", "").Replace("\n", "").Trim();
	}
}