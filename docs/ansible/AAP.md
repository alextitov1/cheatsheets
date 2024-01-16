# Ansible Automation Platform 2.2 Components:

* **Ansible Core 2.13** - shipped with some modules, plugins (battery included)
* **Ansible Content Collections** - additional modules, plugins and roles not included in Ansible Core
* **Automation Content Navigator** - `ansible-navigator`; this tool replaced `ansible-playbook`, `ansible-galaxy` etc.
* **Automation Execution Environment** - a container image that include Ansible Core, Ansible Content Collections, any Python libraries and other dependencies.
* **Automation Controller** - formerly Ansible Tower;
* **(private) Automation Hub**  - non-public version of Ansible galaxy