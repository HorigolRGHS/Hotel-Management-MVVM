using Assigment2_HotelManagement.Models;
using Assigment2_HotelManagement.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Assigment2_HotelManagement.ViewModels
{
    public class RoomManagementViewModel : BaseViewModel
    {
        private RoomInformation selectedRoom;
        public RoomInformation SelectedRoom
        {
            get { return selectedRoom; }
            set
            {
                selectedRoom = value;
                EditedRoom = selectedRoom != null ? CloneRoom(selectedRoom) : null;
                OnPropertyChanged();
            }
        }

        private RoomInformation editedRoom;
        public RoomInformation EditedRoom
        {
            get { return editedRoom; }
            set
            {
                editedRoom = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<RoomInformation> Rooms { get; set; }
        public ObservableCollection<RoomType> RoomTypes { get; set; }

        public ICommand AddRoomCommand { get; set; }
        public ICommand DeleteRoomCommand { get; set; }
        public ICommand UpdateRoomCommand { get; set; }
        public ICommand ClearRoomCommand { get; set; }

        public RoomManagementViewModel()
        {
            LoadRooms();
            LoadRoomTypes();

            SelectedRoom = new RoomInformation();
            EditedRoom = new RoomInformation();

            AddRoomCommand = new RelayCommand(AddRoom);
            DeleteRoomCommand = new RelayCommand(DeleteRoom);
            UpdateRoomCommand = new RelayCommand(UpdateRoom);
            ClearRoomCommand = new RelayCommand(ClearRoom);
        }

        private void LoadRooms()
        {
            using (var context = new FuminiHotelManagementContext())
            {
                var roomsList = context.RoomInformations
                    .Include(r => r.RoomType)
                    .ToList();

                Rooms = new ObservableCollection<RoomInformation>(roomsList);
                OnPropertyChanged(nameof(Rooms));
            }
        }

        private void LoadRoomTypes()
        {
            using (var context = new FuminiHotelManagementContext())
            {
                var roomTypesList = context.RoomTypes.ToList();
                RoomTypes = new ObservableCollection<RoomType>(roomTypesList);
                OnPropertyChanged(nameof(RoomTypes));
            }
        }

        public void AddRoom(object param)
        {
            if (EditedRoom != null)
            {
                using (var context = new FuminiHotelManagementContext())
                {
                    EditedRoom.RoomId = 0;
                    EditedRoom.RoomType = context.RoomTypes.Find(EditedRoom.RoomTypeId);

                    context.RoomInformations.Add(EditedRoom);
                    context.SaveChanges();

                    Rooms.Add(CloneRoom(EditedRoom));
                    OnPropertyChanged(nameof(Rooms));
                }

                ClearRoom(null);
            }
        }


        public void UpdateRoom(object param)
        {
            if (SelectedRoom != null && EditedRoom != null)
            {
                using (var context = new FuminiHotelManagementContext())
                {
                    var roomToUpdate = context.RoomInformations.Include(r => r.RoomType).FirstOrDefault(r => r.RoomId == SelectedRoom.RoomId);
                    if (roomToUpdate != null)
                    {
                        roomToUpdate.RoomNumber = EditedRoom.RoomNumber;
                        roomToUpdate.RoomDetailDescription = EditedRoom.RoomDetailDescription;
                        roomToUpdate.RoomMaxCapacity = EditedRoom.RoomMaxCapacity;
                        roomToUpdate.RoomPricePerDay = EditedRoom.RoomPricePerDay;
                        roomToUpdate.RoomTypeId = EditedRoom.RoomTypeId;
                        roomToUpdate.RoomStatus = EditedRoom.RoomStatus;

                        roomToUpdate.RoomType = context.RoomTypes.Find(EditedRoom.RoomTypeId);

                        context.SaveChanges();

                        var index = Rooms.IndexOf(SelectedRoom);
                        Rooms[index] = CloneRoom(roomToUpdate);
                        OnPropertyChanged(nameof(Rooms));
                    }
                }
            }
        }


        public void DeleteRoom(object param)
        {
            if (SelectedRoom != null)
            {
                using (var context = new FuminiHotelManagementContext())
                {
                    var roomToDelete = context.RoomInformations.Find(SelectedRoom.RoomId);
                    if (roomToDelete != null)
                    {
                        context.RoomInformations.Remove(roomToDelete);
                        context.SaveChanges();

                        Rooms.Remove(SelectedRoom);
                        OnPropertyChanged(nameof(Rooms));
                        ClearRoom(null);
                    }
                }
            }
        }

        public void ClearRoom(object param)
        {
            SelectedRoom = null;
            EditedRoom = new RoomInformation();
            OnPropertyChanged(nameof(SelectedRoom));
            OnPropertyChanged(nameof(EditedRoom));
        }

        private RoomInformation CloneRoom(RoomInformation room)
        {
            return new RoomInformation
            {
                RoomId = room.RoomId,
                RoomNumber = room.RoomNumber,
                RoomDetailDescription = room.RoomDetailDescription,
                RoomMaxCapacity = room.RoomMaxCapacity,
                RoomPricePerDay = room.RoomPricePerDay,
                RoomTypeId = room.RoomTypeId,
                RoomStatus = room.RoomStatus,
                RoomType = room.RoomType
            };
        }

    }
}
