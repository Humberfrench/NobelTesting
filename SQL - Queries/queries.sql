
--query as asked in challenge
SELECT	c.NOMBRE, c.IDCampanya, u.Nombre, t.IdAgente, u.login, 
		DateDiff("dd", c.tinicial, c.tfinal) as DaysOfCampaign, Count(t.IdAgente) as Total
FROM	TRANSACCION t
JOIN	CAMPANYA c
ON		t.IDCampanya = c.IDCampanya
JOIN	USUARIO u
ON		t.IdAgente = u.IdUsuario
GROUP BY t.IdAgente, c.NOMBRE, c.IDCampanya, u.Nombre, u.login, c.tinicial, c.tfinal

--query as asked , with optimizations fields - to better performance
SELECT	t.IdAgente,  Count(t.IdAgente) as Total, c.NOMBRE, c.IDCampanya, 
		DateDiff("dd", c.tinicial, c.tfinal) as DaysOfCampaign, u.Nombre, u.login
FROM	TRANSACCION t
JOIN	CAMPANYA c
ON		t.IDCampanya = c.IDCampanya
JOIN	USUARIO u
ON		t.IdAgente = u.IdUsuario
GROUP BY t.IdAgente, c.NOMBRE, c.IDCampanya, c.tinicial, c.tfinal, u.Nombre, u.login
