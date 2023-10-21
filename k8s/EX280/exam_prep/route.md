# Self-signed cert

```sh
# gen private key
openssl genrsa -out training.key 4096

# gen CSR
openssl req -new \
    -key training.key -out training.csr \
    -subj "/C=US/ST=North Carolina/L=Raleigh/O=Red Hat/\
    CN=todo-https.apps.ocp4.example.com"

# sing cert
openssl x509 -req -in training.csr \
    -signkey training.key \
    -out training.crt -days 1825
```

# Create edge route with a custom key

```sh
oc create route edge my-route --service my-service \
--key training.key --cert mycert.crt \
--hostname my-hostname.apps.ocp4.example.com
```