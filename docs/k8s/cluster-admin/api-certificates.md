# API Certificates

Kubernetes (in a typical kubeadm cluster) includes a cluster CA, and the kube-controller-manager runs the CSR approving/signing controllers that (upon approval) use that CA to sign certificates for components and users.

Signed by the main cluster CA:
- kube-apiserver serving certificate
- kube-controller-manager and kube-scheduler client certificates
- Kubelet client certificates (bootstrap and rotated)
- Kubelet serving certificates (when using signer kubernetes.io/kubelet-serving)
- User / custom client certificates (via CSR, signer kubernetes.io/kube-apiserver-client)

Usually signed by separate authorities or keys:
- etcd: Separate etcd CA (kubeadm creates etcd/ca.crt, ca.key)
- Front-proxy (aggregation layer): front-proxy-ca (front-proxy-ca.crt/key)
- Aggregated / extension API servers: may rely on front-proxy CA for client auth and their own serving certs
- Service account tokens: Signed by service-account key pair (not an x509 CA); projected as JWTs

Notes:
- signerName must match the subject pattern (e.g. kubelet client: CN=system:node:<node>, O=system:nodes).
- A failed CSR with reason SignerValidationFailure often indicates mismatch between signerName, usages, or subject (CN/O).

## User Certificates

User certificates are used to authenticate users to the Kubernetes API server.

Generate a private key and CSR
```sh
openssl req -new -newkey rsa:2048 -nodes -keyout user.key -out user.csr -subj "/CN=akshay/O=devops"
```

Create a CSR object in Kubernetes
```sh
kubectl explain certificatesigningrequest.spec
kubectl get csr (if any exist) -o yaml
```

```yaml
# csr.yaml
apiVersion: certificates.k8s.io/v1
kind: CertificateSigningRequest
metadata:
    name: csr_user
spec:
    request: <base64-encoded-csr>
    signerName: kubernetes.io/kube-apiserver-client
    usages:
    - client authentication
    groups:
    - system:authenticated
```

Create the CSR object
```sh
kubectl apply -f csr.yaml
kubectl get csr
```

Approve the CSR
```sh
kubectl certificate approve csr_user
```







kubectl certificate approve akshay