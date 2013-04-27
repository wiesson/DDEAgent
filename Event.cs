using System;
using System.Collections.Generic;
using System.Text;

namespace DDEAgent {
    class Event {

        private static string _unifiedEvent;
        public static string unifiedEvent {
            // Return the value stored in a field.
            get { return _unifiedEvent; }
            // Store the value in the field.
            set { _unifiedEvent = value; }
        }

        static string[,] dataArr = new string[,] {
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

        public static string Translator(string ddeEvent) {
            for (int i = 0; i < dataArr.GetLength(0); i++) {
                if (dataArr[i, 1].Equals(ddeEvent)) {
                    Console.WriteLine("Event " + dataArr[i, 0] + " Equals " + ddeEvent);
                    unifiedEvent = dataArr[i, 0];
                    break;
                } else {
                    unifiedEvent = "unknown Event :-(";
                }

            }
            return unifiedEvent;
        }
    }
}
