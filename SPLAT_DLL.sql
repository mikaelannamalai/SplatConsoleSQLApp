/***************************************************************************************
*                                                                                      *
* Patrick Larocque    - 0879202                                                        *
* Mikael Annamalai    - 2295010                                                        *
***************************************************************************************/


USE MASTER
GO

DROP DATABASE IF EXISTS SPLAT
GO

CREATE DATABASE SPLAT
GO


USE SPLAT
GO


CREATE TABLE USERS(
    USER_ID INT,
    FULL_NAME VARCHAR(100) NOT NULL,
    EMAIL VARCHAR(255) NOT NULL,
    TITLE VARCHAR(50) NOT NULL,
    USER_NAME VARCHAR(255) UNIQUE NOT NULL,
    PHONE_NUMBER INT,
    CONSTRAINT PK_USERS PRIMARY KEY(USER_ID)
);


CREATE TABLE PROJECTS(
    PROJECT_ID INT NOT NULL,
    CREATED_BY INT NOT NULL,
    PROJECT_NAME VARCHAR(100) NOT NULL,
    START_DATE DATE NOT NULL,
    TARGET_END_DATE DATE NOT NULL,
    ACTUAL_END_DATE DATE,
    CREATED_ON_DATE DATE NOT NULL,
    CONSTRAINT PK_PROJECTS PRIMARY KEY(PROJECT_ID)
);

CREATE TABLE TEAMS(
    TEAM_ID INT,
    USER_ID INT,
    CONSTRAINT PK_TEAMS PRIMARY KEY(TEAM_ID),
    CONSTRAINT FK_TEAMS_01 FOREIGN KEY (USER_ID) REFERENCES USERS(USER_ID),
);

CREATE TABLE PROJECT_TASKS(
    TASK_ID INT NOT NULL,
    PROJECT_ID INT NOT NULL,
    CREATED_BY INT NOT NULL,
    PROJECT_NAME VARCHAR(100) NOT NULL,
    START_DATE DATE NOT NULL,
    TARGET_END_DATE DATE NOT NULL,
    ACTUAL_END_DATE DATE,
    CREATED_ON_DATE DATE NOT NULL,
    CONSTRAINT PK_PROJECT_TASKS PRIMARY KEY(TASK_ID,PROJECT_ID),
    CONSTRAINT FK_PROJECT_TASKS_01 FOREIGN KEY (PROJECT_ID) REFERENCES PROJECTS(PROJECT_ID),
);

CREATE TABLE TICKETS(
    TICKET_ID INT,
    IDENTIFIED_BY INT NOT NULL,
    RELATED_PROJECT INT NOT NULL,
    TITLE VARCHAR(255) NOT NULL,
    DESCRIPTION TEXT,
    DATE_CREATED DATE NOT NULL,
    STATUS VARCHAR(30) NOT NULL,
    PRIORITY VARCHAR (30) NOT NULL,
    CONSTRAINT PK_TICK PRIMARY KEY(TICKET_ID),
    CONSTRAINT FK_TICK_01 FOREIGN KEY (IDENTIFIED_BY) REFERENCES USERS(USER_ID),
    CONSTRAINT FK_TICK_02 FOREIGN KEY (RELATED_PROJECT) REFERENCES PROJECTS(PROJECT_ID)
);

CREATE TABLE ASSIGNED_USERS_TICKETS(
    TICKET_ID INT,
    USER_ID INT,
    CONSTRAINT PK_ASSIGNED_USERS_TICKETS PRIMARY KEY(TICKET_ID,USER_ID),
    CONSTRAINT FK_ASSIGNED_USERS_TICKETS_01 FOREIGN KEY (TICKET_ID) REFERENCES TICKETS(TICKET_ID),
    CONSTRAINT FK_ASSIGNED_USERS_TICKETS_02 FOREIGN KEY (USER_ID) REFERENCES USERS(USER_ID),
);

CREATE TABLE PROJECTS_TEAMS(
    TEAM_ID INT,
    PROJECT_ID INT,
    CONSTRAINT PK_PROJECTS_TEAMS PRIMARY KEY(TEAM_ID,PROJECT_ID),
    CONSTRAINT FK_PROJECTS_TEAMS_01 FOREIGN KEY (TEAM_ID) REFERENCES TEAMS(TEAM_ID),
    CONSTRAINT FK_PROJECTS_TEAMS_02 FOREIGN KEY (PROJECT_ID) REFERENCES PROJECTS(PROJECT_ID),
);

SELECT * FROM USERS;
SELECT * FROM TEAMS;
SELECT * FROM PROJECTS;
SELECT * FROM PROJECT_TASKS;
SELECT * FROM TICKETS;
SELECT * FROM ASSIGNED_USERS_TICKETS;
