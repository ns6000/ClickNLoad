# ClickNLoad

**HOWTO**:

1) Use browser's Inspect on green Click'n Load link element within a web page
2) Copy from "form's opening tag -> onsubmit attribute -> CNLPOP js function" 2nd and 3th parameter along quotes around them (you can even keep the ',' between them...)
3) run: **clickNLoad '<key_chars>', '<encrypted_links_chars>'**
4) ...profit?

Example of text copy (all the text between pair of ###) to the command line parameters:

```html
...
<form action="" target="hidden"
    onsubmit="CNLPOP('<ignore>', ###'1234567890...key_chars', 'abc/j/xyz...encrypted_links_chars'###, '<ignore>'); return false;"
    class="cnlform" method="post">
...
```