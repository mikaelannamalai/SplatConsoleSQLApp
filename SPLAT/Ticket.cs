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
        set { ticketId = value; }
    }

    public int UserId
    {
        get { return userId; }
        set { userId = value; }
    }

    public int ProjectId
    {
        get { return projectId; }
        set { projectId = value; }
    }

    public String Title
    {
        get { return title ; }
        set { title = value; }
    }

    public String Description
    {
        get { return description; }
        set { description = value; }
    }

    public String DateCreated
    {
        get { return dateCreated; }
        set { dateCreated = value; }
    }

    public String Status
    {
        get { return status; }
        set { status = value; }
    }

    public String Priority
    {
        get { return priority; }
        set { priority = value; }
    }

    public String TargetDate
    {
        get { return targetDate; }
        set { targetDate = value; }
    }

    public String ActualDate
    {
        get { return actualDate; }
        set { actualDate = value; }
    }

}
