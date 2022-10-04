using System;
using System.Net.NetworkInformation;

namespace Ticket;
public class Ticket
{
	private int ticketId;
    private int userId;
    private int projectId;
    private String title;
    private String description;
    private String dateCreated;
    private String status;
    private String priority;
    private String targetDate;
    private String actualDate;


    public Ticket()
	{

	}
    public int TicketId
    {
        get { return ticketId; }
        set { ticketId = value; } //db get ticketId
    }

    public int UserId
    {
        get { return userId; }
        set { userId = value; } //db get userId
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

}
