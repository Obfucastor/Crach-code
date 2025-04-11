// button execute
private async void execute_Click(object sender, EventArgs e)
{
    string script = richTextBox1.Text;


    try
    {
        using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(
            ".",
            "ultrafemboysexypipesteaminghotpipe",
            PipeDirection.Out))
        {
            await pipeClient.ConnectAsync();
            byte[] scriptBytes = Encoding.UTF8.GetBytes(script);
            await pipeClient.WriteAsync(scriptBytes, 0, scriptBytes.Length);
            pipeClient.Close();
        }


    }
    catch (Exception ex)
    {

    }

}
// Inject(bypass security)
private void button2_Click(object sender, EventArgs e)
{
    string text = Path.Combine("yourfile.exe");

    {
        Process.Start(new ProcessStartInfo
        {
            FileName = text,
            UseShellExecute = false,
            CreateNoWindow = true,
            WindowStyle = ProcessWindowStyle.Hidden
        });
    }
    if (isinjected())
    {
        MessageBox.Show("injected!");

    }
}
// checkstate Inject
 public bool isinjected()
 {
     try
     {
         using (NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(
             ".",
             "ultrafemboysexypipesteaminghotpipe",
             PipeDirection.Out))
         {
             namedPipeClientStream.Connect(1000);
             return true;
         }
     }
     catch
     {
         return false;
     }
 }
