# Git

git config --global user.name "admin"
git config --global user.email "email@ya.ru"
git config --global push.default simple

# Ansible special tags

* always - always run the task (default)
* never - never run the task

# New collection

meta/runtime.yml
```yml
---
requires_ansible: ">=2.10"
```

