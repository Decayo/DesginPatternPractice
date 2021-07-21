using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Pattern.Command_
{
    /// <summary>
    /// Command 命令物件
    /// </summary>
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
    /// <summary>
    /// Reciever 抽象化 CAMP 
    /// 目的：如果要新增其他種類的SoldierCamp 也是能夠通過此介面進行實作
    /// </summary>
    public interface ICamp{
        void TrainingSoldier();
        void DisableSoldier();
        void UpgradeSoldier();
        void DowngradeSoldier();
    }
    /// <summary>
    /// ConcreteCommand
    /// 內部要有reciever的傳入 ?
    /// </summary>
    public class SoldierTrainingCommand :  ICommand
    {
        ICamp camp;
        public SoldierTrainingCommand (ICamp camp)
        {
            this.camp = camp;
        }
        public void Execute() 
        {
            this.camp.TrainingSoldier();
        }

        public void Undo(){
            this.camp.DisableSoldier();
        }

    }
    public class SoldierUpgradeCommand : ICommand
    {
        ICamp camp;
        public SoldierUpgradeCommand (ICamp camp)
        {
            this.camp = camp;
        }
        public void Execute() 
        {
            this.camp.UpgradeSoldier();
        }

        public void Undo(){
            this.camp.DowngradeSoldier();
        }
    }
    /// <summary>
    /// Reciever
    /// 有基礎兵種以騎兵作為例子
    /// </summary>
    public class BaseSoldierCamp : ICamp
    {
        private string SoldierName = "基本步兵"; 
        protected int TrainingCount = 0;
        protected int UpgradeLevel = 0;
        public void TrainingSoldier(){
            
            Debug.Log("產生1位 "+ SoldierName + "目前共" + (++TrainingCount));
        }
        public void DisableSoldier(){
            if(TrainingCount > 0)
            {
                TrainingCount--;
                Debug.Log("產生1位 "+ SoldierName + "目前共" + TrainingCount);
            }
            else
                Debug.Log(SoldierName + "不存在於目前訓練佇列");

        }
        public void UpgradeSoldier(){
            Debug.Log("升級1位 "+ SoldierName + "目前等級為" + (++UpgradeLevel));
        }
        public void DowngradeSoldier(){
            if(UpgradeLevel > 0){
                UpgradeLevel--;
                Debug.Log("降級1位 "+ SoldierName + "目前等級為" + UpgradeLevel);
            }
            else
                Debug.Log(SoldierName + "不存在於目前升級佇列");
        }

    }
    public class CavalryCamp : ICamp
    {
        private string SoldierName = "騎兵"; 
        protected int TrainingCount = 0;
        protected int UpgradeLevel = 0;
        public void TrainingSoldier(){
            
            Debug.Log("產生1位 "+ SoldierName + "目前共" + (++TrainingCount));
        }
        public void DisableSoldier(){
            if(TrainingCount > 0)
            {
                TrainingCount--;
                Debug.Log("刪除1位 "+ SoldierName + "目前共" + TrainingCount);
            }
            else
                Debug.Log(SoldierName + "不存在於目前訓練佇列");

        }
        public void UpgradeSoldier(){
            Debug.Log("升級1位 "+ SoldierName + "目前等級為" + (++UpgradeLevel));
        }
        public void DowngradeSoldier(){
            if(UpgradeLevel > 0){
                UpgradeLevel--;
                Debug.Log("降級1位 "+ SoldierName + "目前等級為" + UpgradeLevel);
            }
            else
                Debug.Log(SoldierName + "不存在於目前升級佇列");
        }

    }
    /// <summary>
    /// Invoker
    /// 注意這邊將Reciever交由外部client實例化，並當作參數傳入執行
    /// </summary>
    public class CampInvoker{
        List<ICommand> m_commands = new List<ICommand>();
        private int now_index = 0;
        /* reciever 私有化 
        private military = new BaseSoldierCamp();
        */
        public void ExecuteCommand(ICommand command){
            m_commands.Add(command);
            now_index++;
            command.Execute();
        }
        public void UndoCommand(ICommand command){
            if(now_index > 0)
            {
                command.Undo();
                m_commands.Remove(command);
                now_index--;
            }
            else
            {
                Debug.Log("Command : " + command.ToString() +" **Command List Empty**");
            }
        }
        public void ClearCommand(){
            Debug.Log("**Command List Clear**");
            now_index = 0;
            m_commands.Clear();
        }
        
        
    }
}