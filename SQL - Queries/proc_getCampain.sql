
CREATE PROCEDURE GetCampaign 
@CampaignId int = 0,
@AgentId int = 0,
@Finalid int = 0
AS

SELECT	t.IdAgente,  Count(t.IdAgente) as Total, c.NOMBRE, c.IDCampanya, 
		DateDiff("dd", c.tinicial, c.tfinal) as DaysOfCampaign, u.Nombre, u.login
FROM	TRANSACCION t
JOIN	CAMPANYA c
ON		t.IDCampanya = c.IDCampanya
JOIN	USUARIO u
ON		t.IdAgente = u.IdUsuario
WHERE	(c.IDCampanya = @CampaignId OR @CampaignId = 0)
AND		(t.IdAgente = @AgentId OR @AgentId = 0)
AND		(t.idFinal = @Finalid OR @Finalid = 0)
GROUP BY t.IdAgente, c.NOMBRE, c.IDCampanya, c.tinicial, c.tfinal, u.Nombre, u.login

