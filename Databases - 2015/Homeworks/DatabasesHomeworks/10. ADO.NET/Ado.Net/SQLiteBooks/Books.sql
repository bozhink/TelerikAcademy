﻿CREATE TABLE `Books` (
	`Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`Title`	TEXT NOT NULL,
	`Author`	TEXT NOT NULL,
	`PublishDate`	TEXT,
	`ISBN`	TEXT
);