# Kubelet

Kubelet - An agent that runs on each node in a Kubernetes cluster, responsible for managing the lifecycle of containers in pods. It ensures that the containers are running as expected, reports their status to the API server, and can also handle tasks like logging and monitoring.

```sh
# Installation
curl -LO https://storage.googleapis.com/kubernetes-release/release/$(curl -s https://storage.googleapis.com/kubernetes-release/release/stable.txt)/bin/linux/amd64/kubelet

# Run as a service
cat <<EOF | sudo tee /etc/systemd/system/kubelet.service
[Unit]
Description=Kubernetes Kubelet
Documentation=https://kubernetes.io/docs/concepts/architecture/kubelet/
After=network.target
[Service]
ExecStart=/usr/local/bin/kubelet \\
    --config=/etc/kubernetes/kubelet.yaml \\
    --kubeconfig=/etc/kubernetes/kubelet.conf \\
    --container-runtime-endpoint=unix:///run/containerd/containerd.sock \\
    --image-pull-progress-deadline=2m \\
    --v=2
Restart=always
RestartSec=10s
EOF

# Troubleshooting
ps -aux | grep kubelet