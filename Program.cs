using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDEAgent {
    class Program {
        static void Main(string[] args) {
           // Configuration.LoadFile();

            string datetime = DateTime.Now.ToString("yyMMdd-HHmmssfff");
            Console.WriteLine(datetime);
            string[,] dataArr = new string[,] {
                {"SPINDLE_SPEED","/Channel/Spindle/cmdSpeed[1]" },
		        {"SPINDLE_OVR","/Channel/Spindle/speedOvr[1]" },
		        {"SPINDLE_LOAD","/Channel/Spindle/driveLoad[1]" },
		        {"POSITION_X","/Channel/MachineAxis/actToolBasePos[1]" },
		        {"POSITION_Y","/Channel/MachineAxis/actToolBasePos[2]" },
		        {"POSITION_Z","/Channel/MachineAxis/actToolBasePos[3]" },
		        {"PROGRAM_STATUS","/Channel/ProgramInfo/progName" },
		        {"LINE","/Channel/ProgramInfo/actLineNumber" },
		        {"BLOCK","/Channel/ProgramInfo/singleBlock[2]" },
		        {"PROGRAM","/Channel/ProgramInfo/progNamePROGRAM" },
		        {"PATH_FEEDRATE","/Channel/State/actFeedRateIpo" },
		        {"PATH_FEEDRATEOVR","/Channel/State/feedRateIpoOvr" },
		        {"TOOL_NUMBER","/Channel/State/actTNumber" },
		        {"EXECUTION","/Channel/State/progStatus" },
		        {"PROGRAM_STATUS","/Channel/ProgramPointer/actInvocCount" },
		        {"CONTROLLER_MODE","/Bag/State/opMode" },
		        {"ALARM","/Channel/State/chanAlarm" }
            };

            for (int i = 0; i < 1 /*dataArr.GetLength(0)*/ ; i++) {
                Network.TcpClient(dataArr[i, 0], datetime);    
                System.Console.WriteLine(i + ":" + dataArr[i, 0] + "->" + dataArr[i, 1]);
            }

            string test = Console.ReadLine();
            
        }
    }
}