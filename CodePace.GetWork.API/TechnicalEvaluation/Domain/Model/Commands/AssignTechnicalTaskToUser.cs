﻿namespace CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Commands;

public record AssignTechnicalTaskToUser(int UserId, int TechnicalTestId);