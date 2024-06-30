using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLibrary {
    public class Collision2D {

        public Collider2D ColliderA { get; private set; }
        public Collider2D ColliderB { get; private set; }
        public int ContactCount => contacts.Count;

        private List<ContactPoint2D> contacts = new List<ContactPoint2D>();

        public Collision2D(Collider2D colliderA, Collider2D colliderB) {
            this.ColliderA = colliderA;
            this.ColliderB = colliderB;
        }

        public void AddContact(ContactPoint2D contact) => contacts.Add(contact);

        public int GetContacts(List<ContactPoint2D> contacts) {
            contacts.Clear();
            contacts.AddRange(this.contacts);
            return contacts.Count;
        }
    }
}
