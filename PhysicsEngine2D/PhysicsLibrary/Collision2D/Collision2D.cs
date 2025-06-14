﻿
namespace PhysicsLibrary {
    public class Collision2D {

        public Collider2D ColliderA { get; private set; }
        public Collider2D ColliderB { get; private set; }
        public int ContactCount => contacts.Count;

        readonly List<ContactPoint2D> contacts = new();

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
