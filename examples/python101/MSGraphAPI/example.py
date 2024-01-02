import requests
import json

app_id = 'aa620931-7108-4e58-9440-2aa29131c29d' #Application Id - on the azure app overview page
client_secret = 'secret' 
#Use the redirect URL to create a token url
token_url = 'https://login.microsoftonline.com/648022e0-0a58-4c77-86c6-1241a1d6866f/oauth2/token'
token_data = {
 'grant_type': 'client_credentials',
 'client_id': app_id,
 'client_secret': client_secret,
 'resource': 'https://graph.microsoft.com',
 'scope':'https://graph.microsoft.com/.default'
}

token_r = requests.post(token_url, data=token_data)
token = token_r.json().get('access_token')

#print(token_r.content)
#print(token)

#user_id = '677ab46c-55ce-4e49-a7d7-62f0377d7351' #me
user_id = '7b077796-b7bd-4e9e-a0b2-fff52933ff20' # 1C auto orders

users_url = 'https://graph.microsoft.com/v1.0/users/{}/mailFolders/Inbox/messages'.format(user_id)

headers = {
 'Authorization': 'Bearer {}'.format(token)
}
maillist = json.loads(requests.get(users_url, headers=headers).text)
#maillist = requests.get(users_url, headers=headers).text
for mail in maillist['value']:
    print(mail['subject'])

