Clean up the code architecture. Separate the model and the service

The model should have an ID (unique value)

Gain XP amount NEEDS to know which user to give XP to. In the parameter include id as well

Implement a way to store user

Implement a way to retrieve all players. (This could in the future be expanded to a leader board for example.)

If Xp is a negative number, throw an exception.

# XP System - API Contract Specification

This document defines the interface contract between the client and the server for the XP System API.

## 1. Endpoint: Gain Experience Points
Allows a player to gain a specific amount of experience points (XP).

* **URL:** `/api/players/{id}/xp`
* **Method:** `POST`
* **Content-Type:** `application/json`

### Request Parameters
| Name | Type | Location | Description |
| :--- | :--- | :--- | :--- |
| `id` | `int` | Path | The unique identifier of the player. |

### Request Body
```json
{
  "amount": "int (The amount of XP to add)"
}

