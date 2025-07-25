# Email Checker Lite ✉️

Open-source .NET tool to validate email addresses by checking:

✅ Syntax  
✅ Domain existence  
✅ MX records  

---

## 🔧 Usage

1. Clone the repo  
2. Open in Visual Studio  
3. Build & run the console app  
4. Enter path to a `.csv` or `.txt` file containing emails (one per line)  
5. The result will be saved to `results.csv` in the same directory

---

## 🧪 Example

Input file (`emails.csv`):
john@example.com
not-an-email
info@mailinator.com


Output (`results.csv`):
Email,ValidSyntax,DomainExists,HasMX
john@example.com,true,true,true
not-an-email,false,false,false
info@mailinator.com,true,true,true


---

## 📦 Features in progress

- [ ] Support for `.xlsx` input  
- [ ] Disposable email detection  
- [ ] CLI arguments (`--input --output`)  
- [ ] Web UI frontend  
- [ ] Docker support  

---

## 📝 License

This project is licensed under the MIT License. See [LICENSE](LICENSE) for details.

