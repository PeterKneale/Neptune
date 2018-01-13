API

PROFILES
-------
Profile
 - Id
 - Name
 - Reputation
 - Gold
 - Silver
 - Bronze
 - CreatedAt

IDENTITY
--------

QANDA
-----
Question
 - Id
 - Title
 - Body
 - Views
 - CreatedAt
 - CreatedById
 - CreatedByName
 - UpdatedAt
 - UpdatedById
 - UpdatedByName
 - LastActivity

Question Votes
 - Id
 - QuestionId
 - UserId

Question Stars
 - Id
 - QuestionId
 - UserId

Question Tags
 - Id
 - Name

Answer
 - Id
 - QuestionId
 - Body
 - Accepted
 - AcceptedAt
 - AcceptedById
 - AcceptedByName
 - CreatedAt
 - CreatedById
 - CreatedByName
 - UpdatedAt
 - UpdatedById
 - UpdatedByName

Answer Votes
 - Id
 - QuestionId
 - UserId

Events
QuestionCreated
 - Id
QuestionUpdated
 - Id
QuestionStarred
 - Id
QuestionVotedOn
 - Id
AnswerCreated
 - Id
AnswerUpdated
 - Id
AnswerAccepted
 - Id
AnswerVotedOn
 - Id

Subscriptions
 QuestionUpdated, Starred, VotedOn, AnswerCreated, Updated, Accepted, Votes on -> Update LastActivityDate

SEARCH
------
QuestionIndex
 - Id
 - Title
 - Body
 - Tags
 - Votes
 - Answers
 - AcceptedAnswer
 - CreatedAt
 - CreatedByAt
 - CreatedByName

Subscribes to all events