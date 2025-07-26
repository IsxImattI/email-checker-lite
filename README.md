# Email Checker Lite ✉️

![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet)
![Status](https://img.shields.io/badge/build-passing-brightgreen)
![License: MIT](https://img.shields.io/badge/license-MIT-blue)

Open-source .NET CLI tool to validate email addresses by checking:

✅ Syntax  
✅ Domain existence  
✅ MX records  
✅ Disposable domain detection

---

## 🔧 Usage

1. Clone the repo  
2. Open in Visual Studio  
3. Build & run the console app  
4. Provide the path to a `.csv`, `.txt`, or `.xlsx` file containing emails (one per line in the first column)  
5. The result will be saved to `results.csv` (or your custom output path)

---

## 🧪 Example

**Input file (`emails.csv`):**
```
john@example.com
not-an-email
info@mailinator.com
```

**Output (`results.csv`):**
```
Email,ValidSyntax,DomainExists,HasMX,IsDisposable
john@example.com,true,true,true,false
not-an-email,false,false,false,false
info@mailinator.com,true,true,true,true
```

---

## 📦 Features

- [x] Disposable email detection  
- [x] Support for `.xlsx` input  
- [ ] CLI arguments (`--input`, `--output`)  
- [ ] Web UI frontend  
- [ ] Docker support  

---

## 👥 Contributors

- [@IsxImattI](https://github.com/IsxImattI) – author

---

## 📝 License

This project is licensed under the MIT License. See [LICENSE](LICENSE) for full details.
