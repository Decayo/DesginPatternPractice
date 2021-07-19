# Command Pattern 命令模式


> Encapsulate a request as an object, thereby letting you parameterize clients with
> different requests, queue or log requests, and support undoable operations. 
>   
    
> 將請求封裝為物件，使你藉由不同的請求 (如: 佇列或日誌請求)，
> 對客戶端請求參數化，並支援可取消的操作。

  任何具有或需要還原性質的功能皆可實作該模式，成員解釋完成後有更具體的冥數：
  - Ctrl+Z的還原命令
  - 多指令一口氣執行的命令
  - 如：點餐、組裝、上下上下左右ABAB等
  - 佇列性質的一連串命令 (訓練、升級指令等待排發)
  - 請求的封裝與請求的操作
  
  
**主要實現 佇列 (Queue)、日誌 (Log)、復原 (undoable)**  

### 成員圖解
![](https://i.imgur.com/qNDp1em.png)
### 程式執行順序圖解
![](https://i.imgur.com/N9sr0Ln.png)  
(僅參考，計算機範例是通過先建立Invoker在其內部繼續建立Reciever)
- ![](https://i.imgur.com/5pHPADY.png)  
通常案例如上  

具體其他變形案例，如下計算機為
1. 封裝接收者 (Encapsulate Receiver)  
    - 可以降低Client(高)對Reciever(低)的依賴
    - Client職責更明確，不需組裝Reciever
    - Clinet僅考慮給予Invoker ConcreteCommand(具體命令)
    - 可能造成耦合加重，須注意Reciever和Invoker職責的界線
2. 職責分離 (Client — Segregation of Duties)  
        - 交給"新"的類別來組裝
        - 如"點餐"原本可以替換成呼叫"服務生"
        - 再藉由"服務生"去後場進行"命令"
        - 客戶 (Client) 準備好命令 (ConcreteCommand) 再傳遞給Invoker 即可。

3. 智慧命令  
    命令 (Command) 不再需要 接收者 (Receiver)，
    自己就知道怎麼實現功能 



### 具體成員可細分成6類，以計算機為例

- Client  
   - 命令的發起者
   - 建立具體的命令Object
   - 某些情況會設定命令給Reciever(接受者)
   - 就是main或者update ， 主要進行所有東西的實例化之最上層介面
   - ![](https://i.imgur.com/FxZ7ryR.png)

   
- Reciever  
   - 功能的執行者 
   - 被封裝在 ConcreteCommand 類別中，執行功能的類別物件
   - 實現命令請求的類別皆為Reciever
   - ![](https://i.imgur.com/4nTvygV.png)



- Invoker  
   - 命令的管理者，通常會有List、Arrary、PriorityQueue容器盛裝命令佇列
   - 建立具體的命令Object
   - 設定接受者
   - Client比起客戶，更像是創造接收對象之接受者
   - ![](https://i.imgur.com/x7fIDB4.png)


  
- Command  
   - 定義"命令"封裝後要具備的操作介面 (如 Execute / Undo ) 
   - ![](https://i.imgur.com/25RdXtO.png)

- ConcreteCommand  
   - 命令的實作者
   - 實作命令封裝及介面，包含每一個命令的參數及通常持有接收者
   - ![](https://i.imgur.com/bfDa8eI.png)


## 結論



優點| 缺點 |
| -------- | -------- |
| 降低耦合  |大量Class去達成一個目標：計算機僅為了簡單計算已經建立了4~5個class，需要特別注意使用量|
| 易擴充新命令 |任何獨立的指令皆可是一個 ConcreteCommand |  
/| 將 函式的角色 提升至 類別的層次

### 擴充補充以及其缺點講解
> 新增一個命令物件(ConcreteCommand)，如廚師新增菜單、遊戲解鎖新兵種、新的升級、3c多了個按鈕的功能等，並實作Execute的效果即可，也可以預見如果你命令一大堆，那就是有大量的ConcreteCommand Class
## 適用環境
- 符合了**單一職責原則**
- 時間的解耦
- 需要將調用者和請求接受者解耦，使Invoker 和 Reciever 不直接交互
- 需要在不同時間指定請求，將請節進行排隊並執行
- 需要撤銷、恢復等操作
- 需要將一組操作組合，形成一種命令

## 待做
## 復原功能探討
## 與其他模式的聯動

## 參考：
https://notfalse.net/4/command-pattern