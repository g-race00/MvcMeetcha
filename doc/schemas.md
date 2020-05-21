# AspNetUsers

    Id                    nvarchar(900)   primary
    UserName              nvarchar(512)? 
    NormalizedUserName    nvarchar(512)?  unique
    Email                 nvarchar(512)? 
    NormalizedEmail       nvarchar(512)?  index
    EmailConfirmed        bit
    PasswordHash          nvarchar(max)?
    SecurityStamp         nvarchar(max)?
    ConcurrencyStamp      nvarchar(max)?
    PhoneNumber           nvarchar(max)?
    PhoneNumberConfirmed  bit
    TwoFactorEnabled      bit
    LockoutEnd            datetimeoffset?
    LockoutEnabled        bit
    AccessFailedCount     int

# Admins

    Id            int            primary 
    AspNetUserId  nvarchar(900)  unique foreign AspNetUsers.Id
                                                           
# Members

    Id            int            primary 
    AspNetUserId  nvarchar(900)  unique foreign AspNetUsers.Id

# GroupTypes

    Id           int            primary
    Name         nvarchar(64)   unique

# Groups

    Id           int            primary
    Name         nvarchar(128)  unique
    GroupTypeId  int            index foreign GroupTypes.Id
    Image        nvarchar(max)
    Description  nvarchar(max)

# MeetupTypes

    Id           int            primary
    Name         nvarchar(64)   unique

# Meetups

    Id            int             primary
    Name          nvarchar(128)   
    GroupId       int             index foreign Groups.Id
    MeetupTypeId  int             index foreign MeetupTypes.Id
    Date          date            
    StartTime     time
    EndTime       time
    Venue         nvarchar(512)
    Fee           smallmoney
    Status        nvarchar(64)
    HostId        int             index foreign Members.Id
    Image         nvarchar(max)
    Description   nvarchar(max)

# GroupComments

    Id           int             primary
    CommenterId  int             index foreign Members.Id
    GroupId      int             index foreign Groups.Id
    DateAndTime  datetime2
    Content      nvarchar(max)

# MeetupComments

    Id           int             primary
    CommenterId  int             index foreign Members.Id
    MeetupId     int             index foreign Meetups.Id
    DateAndTime  datetime2
    Content      nvarchar(max)

# GroupMembers

    GroupId     int             foreign Groups.Id
    MemberId    int             foreign Members.Id
    Role        nvarchar(64)
    JoinedDate  datetime2

    primary(GroupId, MemberId)
    index(MemberId, GroupId)

# MeetupAttendees

    MeetupId    int  foreign Meetups.Id
    MemberId    int  foreign Members.Id

    primary(MeetupId, MemberId)
    index(MemberId, MeetupId)
