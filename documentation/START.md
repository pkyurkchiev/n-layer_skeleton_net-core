Request for token
	address: http://localhost:64704/token
	body: username = TEST
		  password = TEST123
	response: access_token and expires_in

===================================================

Request to API
	address: http://localhost:64704/api/users
	headers: Authorization = Bearer access_token