using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFASimulator1
{
    class DFASimulation
    {
        public static List<string> Acceptedstates = new List<string> {"s1", "s2"};// accepted states creation
        public static List<string> FinalState = new List<string> {"s8","s10"};//terminal states creation
        public static List<string> Deadend=new List<string>();//when a state leads to a deadend we add it in this list
        private static int position = 0;//a variable which displays the current position in the txt file
        private static int accepted_position = 0;// a variable with the last accepted position
        private static string last_accepted_state;// a variable with the last accepted state
        private static char m_char;
        public static List<State> DFAGraph = new List<State>
        {//we create a DFA graph with states
            new State("s0",'a',"s1"),
            new State ("s1",'b',"s2"),
            new State("s2",'a',"s3"),
            new State("s3",'c',"s4"),
            new State("s4",'a',"s7"),
            new State("s2",'a',"s5"),
            new State("s5",'c',"s6"),
            new State("s6",'b',"s8"),
            new State("s5",'c',"s9"),
            new State("s9",'d',"s10")
        };
        public static string m_currentState = "s0";// a variable to display the current state
        public static void Simulation(StreamReader stream)
        {
            bool flag = true;
            FLEXStream fstream = new FLEXStream(stream);
            //we get the first character from the txt file
            m_char = fstream.NextChar(position);
                for (int i = 0; i < DFAGraph.Count(); i++)
                {
                    //if the current state is the same with the current start state of the DFAGraph and the current end state doesn't lead to a deadend 
                    if (m_currentState.Equals(DFAGraph[i].StartState) && !(Deadend.Contains(DFAGraph[i].EndState)))
                    {
                        //if the character from the stream is the same with the current token
                        if (m_char.Equals(DFAGraph[i].Token))
                        {
                            //if the current state is also an accepted state then we update the accepted_position and the last_accepted_state variables
                            if (Acceptedstates.Contains(m_currentState))
                            {
                                accepted_position = position;
                                last_accepted_state = m_currentState;
                            }
                            //we print the start state and the end state
                            Console.WriteLine("{0} ->  {1}\n",DFAGraph[i].StartState,DFAGraph[i].EndState);
                            //the current end state becomes the new current state
                            m_currentState = DFAGraph[i].EndState;
                            position++;
                            //we get the next character from the txt file
                            m_char = fstream.NextChar(position);
                            i = -1;
                           

                        }

                    }

                    if (i == DFAGraph.Count - 1)
                    {
                        //if the current state is also a final state the DFA is acceptable
                        if (FinalState.Contains(m_currentState))
                        {
                            Console.WriteLine("The Dfa is accepted");
                            break;
                        }
                        //if the current state leads to a deadend the DFA is unacceptable
                        if (Deadend.Contains(m_currentState))
                        {
                            Console.WriteLine("The DFA is not accepted");
                            break;
                        }
                        Deadend.Add(m_currentState);//add the current state in the list of deadend states
                        //the position and the m_currentState variables get the values of the latest accepted position and accepted state
                        position = accepted_position;
                        m_currentState = last_accepted_state;
                        //we get the next character from the txt file
                        m_char = fstream.NextChar(position);
                        i = -1;
                    }
                }


                
          
        }
    }
}
