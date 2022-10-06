using SPLAT;
using System;
using System.Collections;
using System.Net.NetworkInformation;

namespace Ticket;
public class TicketController
{
    /*	private int ticketId;
        private int userId;
        private int projectId;
        private String title;
        private String description;
        private String dateCreated;
        private String status;
        private String priority;
        private String targetDate;
        private String actualDate;
    */
//  private static DB db = db.getInstance(); //TODO
    private static TicketController? instance;
    private int selectedTicketID = -1;
    private static DB db = DB.getInstance();


    public static TicketController getInstance()
	{
        if (instance == null) instance= new TicketController();
        return instance;
	}

    public void selectTicket(int ID)
    {
        this.selectedTicketID = ID;
    }

   /* public ArrayList <int> getProductIDs() ////TODO
    {
        ResultSet rs = DB.getInstance().getAll(DB.TICKETS_TABLE);


    }
   */


    public int GetTicketID()
    {
         return selectedTicketID; 
 
    }

    public string UserId
    {
        get { 
            enforceTicketSelected( "getUserId()" );
            return db.get(DB.TICKETS_TABLE, GetTicketID(), "USERID");   
        
        }
        set {
            DB.getInstance().update(DB.TICKETS_TABLE, GetTicketID(), "USERID", value);
        } //db get userId
    }

    public int ProjectId
    {
        get { return projectId; }
        set { projectId = value; } //db get projectId
    }

    public String Title
    {
        get { return title ; }
        set { title = value; }  //db get title
    }

    public String Description
    {
        get { return description; }
        set { description = value; }    //db get description
    }

    public String DateCreated
    {
        get { return dateCreated; }
        set { dateCreated = value; }      //db get dateCreated
    }

    public String Status
    {
        get { return status; }
        set { status = value; }         //db get status
    }

    public String Priority
    {
        get { return priority; }
        set { priority = value; }       //db get priority
    }

    public String TargetDate
    {
        get { return targetDate; }
        set { targetDate = value; }     //db get targetDate
    }

    public String ActualDate
    {
        get { return actualDate; }
        set { actualDate = value; }     //db get actualDate
    }
    private void enforceTicketSelected(string v)
    {
        throw new NotImplementedException();
    }
}
