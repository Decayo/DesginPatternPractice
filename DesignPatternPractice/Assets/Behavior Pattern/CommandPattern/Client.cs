namespace Pattern.Command_
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    public class Client : MonoBehaviour
    {
        ICommand m_training_command = null;
        ICommand m_update_command = null;
        CampInvoker m_invoker;
        BaseSoldierCamp base_soldier_reciever ;
        CavalryCamp cavalry_reciever;
        void Start(){
            m_invoker = new CampInvoker();
            base_soldier_reciever = new BaseSoldierCamp();
            cavalry_reciever = new CavalryCamp();
            // Unit test
            m_training_command = new SoldierTrainingCommand(base_soldier_reciever);
            m_update_command = new SoldierUpgradeCommand(base_soldier_reciever);

            m_invoker.ExecuteCommand(m_training_command);
            m_invoker.ExecuteCommand(m_training_command);
            m_invoker.ExecuteCommand(m_update_command);
            m_invoker.UndoCommand(m_update_command); 
            m_invoker.ExecuteCommand(m_update_command);
            m_invoker.ExecuteCommand(m_training_command);
            m_invoker.UndoCommand(m_update_command);
            m_invoker.UndoCommand(m_update_command);
            m_invoker.UndoCommand(m_training_command);
            m_invoker.UndoCommand(m_training_command);
            m_invoker.UndoCommand(m_training_command);
            m_invoker.UndoCommand(m_update_command);
            m_invoker.UndoCommand(m_training_command);

            m_training_command = new SoldierTrainingCommand(cavalry_reciever);
            m_update_command = new SoldierUpgradeCommand(cavalry_reciever);

            m_invoker.ExecuteCommand(m_training_command); 
            m_invoker.ExecuteCommand(m_update_command);
            m_invoker.UndoCommand(m_training_command); 
            m_invoker.UndoCommand(m_update_command); 
            m_invoker.UndoCommand(m_training_command);
            m_invoker.ExecuteCommand(m_training_command); 
            m_invoker.ExecuteCommand(m_training_command); 
            m_invoker.ExecuteCommand(m_training_command);

        }
    }
}