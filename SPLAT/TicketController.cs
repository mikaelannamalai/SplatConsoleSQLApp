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
    public void addTicket(int userID, int projectID, String title, String description, String date, String status, String priority, String target_date )
    {
        // Insert into ticket table
        DB.getInstance().insert(
            DB.TICKETS_TABLE,
            new String[] { "IDENTIFIED_BY", "RELATED_PROJECT", "TITLE", "DESCRIPTION", "DATE_CREATED", "STATUS", "PRIORITY", "TARGET_END_DATE" },
            new String[] { userID+"", projectID + "", title, description, date, status, priority, target_date }
        );
    }


    public int getTicketID()
    {
         return selectedTicketID; 
 
    }

    public string userId
    {
        get { 
            enforceTicketSelected( "getTicketId()" );
            return db.get(DB.TICKETS_TABLE, getTicketID(), "USERID");   
        
        }
        set {
            DB.getInstance().update(DB.TICKETS_TABLE, getTicketID(), "USERID", value);
        } //db get userId
    }

    public string projectId
    {
        get {
            enforceTicketSelected("getUserId()");
            return db.get(DB.TICKETS_TABLE, getTicketID(), "PROJECTID");

        }
        set { 
            DB.getInstance().update(DB.TICKETS_TABLE, getTicketID(), "USERID", value);

        } //db get projectId
    }

    public String title
    {
        get { return title ; }
        set { title = value; }  //db get title
    }

    public String description
    {
        get { return description; }
        set { description = value; }    //db get description
    }

    public String dateCreated
    {
        get { return dateCreated; }
        set { dateCreated = value; }      //db get dateCreated
    }

    public String status
    {
        get { return status; }
        set { status = value; }         //db get status
    }

    public String priority
    {
        get { return priority; }
        set { priority = value; }       //db get priority
    }

    public String targetDate
    {
        get { return targetDate; }
        set { targetDate = value; }     //db get targetDate
    }

    public String actualDate
    {
        get { return actualDate; }
        set { actualDate = value; }     //db get actualDate
    }
    private void enforceTicketSelected(string v)
    {
        throw new NotImplementedException();
    }
}
