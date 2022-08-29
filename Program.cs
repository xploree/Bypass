using System.Diagnostics;
using Bypass.Utils;

class Program
{

    static bool hasFoundProcess = false;

    static string procName = "Figma";

    static BypassConsole console = BypassConsole.Instance;

    static Process[]? localByName;
    private static bool shouldDebug = false;

    public static void Main()
    {
        if(shouldDebug)
        {
            console.LogNote("Process List Grabbed");
            Process[] procArray = ProcessViewer.Instance.GetAllProcesses();

            TextWriter tsw = new StreamWriter("debug.txt", true);

            foreach (Process theprocess in procArray)
            {
                tsw.Write(theprocess.ProcessName + "\n");
                console.LogNote("Process Written");
            }
        }


        console.LogNote("Awaiting Process Startup...");

        while(!hasFoundProcess)
        {
            console.Line();

            localByName = Process.GetProcessesByName(procName);

            if (localByName.Length == 0)
            {
                console.LogError("Process Not Found");
            } else
            {
                console.LogNote("Process Found");
                hasFoundProcess = true;
            }
            Thread.Sleep(5000);
        }

        console.Line();

        console.LogNote("Hooking Onto Process");
        Thread.Sleep(2000);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        foreach (Process worker in localByName)
        {
            console.LogNote("Killing Process");
            worker.Kill();
            Thread.Sleep(1000);
            console.LogNote("Waiting on Exit...");
            worker.WaitForExit();
            Thread.Sleep(1000);
            console.LogNote("Disposing");
            worker.Dispose();
            Thread.Sleep(3000);

            console.Line();
            console.LogNote("Process Closing Complete");
        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        Thread.Sleep(1000);
        console.Line();
        console.LogNote("Program Lifetime Complete");

    }

    public void Callback(object? state)
    {
        console.LogNote("Process Not Found");
        
    }
}