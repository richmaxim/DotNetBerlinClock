
Feature: The Berlin Clock
	As a clock enthusiast
    I want to tell the time using the Berlin Clock
    So that I can increase the number of ways that I can read the time


Scenario: Midnight 00:00
When the time is "00:00:00"
Then the clock should look like
"""
Y
OOOO
OOOO
OOOOOOOOOOO
OOOO
"""

Scenario: Just after Midnight 00:00
When the time is "00:00:01"
Then the clock should look like
"""
O
OOOO
OOOO
OOOOOOOOOOO
OOOO
"""

Scenario: Middle of the afternoon
When the time is "13:17:01"
Then the clock should look like
"""
O
RROO
RRRO
YYROOOOOOOO
YYOO
"""

Scenario: Just before midnight
When the time is "23:59:59"
Then the clock should look like
"""
O
RRRR
RRRO
YYRYYRYYRYY
YYYY
"""

Scenario: Midnight 24:00
When the time is "24:00:00"
Then the clock should look like
"""
Y
RRRR
RRRR
OOOOOOOOOOO
OOOO
"""

Scenario: Time is 20:00:40
When the time is "20:00:40"
Then the clock should look like
"""
Y
RRRR
OOOO
OOOOOOOOOOO
OOOO
"""

Scenario: Time is 23:05:41
When the time is "23:05:41"
Then the clock should look like
"""
O
RRRR
RRRO
YOOOOOOOOOO
OOOO
"""

Scenario: Time is 23:10:42
When the time is "23:10:42"
Then the clock should look like
"""
Y
RRRR
RRRO
YYOOOOOOOOO
OOOO
"""

Scenario: Time is first quarter of an hour
When the time is "23:15:43"
Then the clock should look like
"""
O
RRRR
RRRO
YYROOOOOOOO
OOOO
"""

Scenario: Time is half of an hour
When the time is "23:30:43"
Then the clock should look like
"""
O
RRRR
RRRO
YYRYYROOOOO
OOOO
"""

Scenario: Time is last quarter of an hour
When the time is "23:45:43"
Then the clock should look like
"""
O
RRRR
RRRO
YYRYYRYYROO
OOOO
"""

Scenario: Time is 23:50:44
When the time is "23:50:44"
Then the clock should look like
"""
Y
RRRR
RRRO
YYRYYRYYRYO
OOOO
"""

Scenario: Time is 13:16:01
When the time is "13:16:01"
Then the clock should look like
"""
O
RROO
RRRO
YYROOOOOOOO
YOOO
"""

Scenario: Time is 13:18:02
When the time is "13:18:02"
Then the clock should look like
"""
Y
RROO
RRRO
YYROOOOOOOO
YYYO
"""

Scenario: Time is null
When the time is null
Then the ArgumentNullException is thrown

Scenario: Time is empty
When the time is invalid like ""
Then the FormatException is thrown

Scenario: Time has bad format
When the time is invalid like "some string"
Then the FormatException is thrown

Scenario: Time has out of boundaries hours
When the time is invalid like "28:23:59"
Then the OverflowException is thrown

Scenario: Time has out of boundaries minutes
When the time is invalid like "12:60:13"
Then the OverflowException is thrown

Scenario: Time has out of boundaries seconds
When the time is invalid like "23:03:61"
Then the OverflowException is thrown

Scenario: Time has out of boundaries period
When the time is invalid like "24:00:01"
Then the OverflowException is thrown