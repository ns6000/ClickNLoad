using System.Reflection;
using System.Security.Cryptography;
using System.Text;

internal class App
{
	private static async Task Main(string[] args)
	{
		if(args.Length < 2)
			throw new ArgumentException($"Not enough arguments. Usage: {Assembly.GetEntryAssembly()!.Location} \"key\"[,] \"data\" [\"links_filename\"]");

		string key	= string.Join(string.Empty, args[0].TakeWhile(ch => ch != ',')).ToUpper();
		byte[] data	= Convert.FromBase64String(args[1]);

		// decode key
		string decKey = "";
		for(int i = 0; i < key.Length; i += 2)
			decKey += (char)Convert.ToUInt16(key.Substring(i, 2), 16);

		// decrypt that shit!
		#pragma warning disable SYSLIB0022
		RijndaelManaged rDel	= new();
		rDel.Key				= Encoding.ASCII.GetBytes(decKey);
		rDel.IV					= Encoding.ASCII.GetBytes(decKey);
		rDel.Mode				= CipherMode.CBC;
		rDel.Padding			= PaddingMode.None;

		ICryptoTransform cTransform	= rDel.CreateDecryptor();
		byte[] resultArray			= cTransform.TransformFinalBlock(data, 0, data.Length);

		string files = Encoding.ASCII.GetString(resultArray).Replace("\0", string.Empty);
		if(args.Length > 2)
			await File.WriteAllTextAsync(args[2], files);
		else Console.WriteLine(files);
	}
}