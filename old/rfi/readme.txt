Features

Data per person
PC/NPC
Name
Mini Code
Initiative
Status Stack
Mark (source)
Health

// from common db
action points
surges

Actions
Load party
Load encounter
Add Monster (with quantity)
Set init (single or all for monsters)
Add status
Add Damanage
Sort
Next


Notifications
Death (NPC)
Death (PC)
Save


Status info
Name
End cond (turn, save)
Effect (neg to all, neg to def, neg to attack)


database constructs

PC:
	Name
	GUID
	Player
	Stats
	Health (max)
	Surges (max)
	Defenses

NPC
	Name
	Type
	HP
	Stats

PC Status:
	PC GUID
	Current Health
	Current Surges
	

Party
	Name
	GUID
	PC Status List



