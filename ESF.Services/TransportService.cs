using System.Collections.Generic;
using ESF.Commons.Repository;
using ESF.Core.Repositories;
using ESF.Core.Services;
using ESF.Domain;
using System;
using ESF.Commons.Utilities;
using ESF.Core.Services.Models;

namespace ESF.Services
{
    public class TransportService : ITransportService
    {
        private readonly ITransportPickupPointRepository transportPickupPointRepository;
        private readonly ITransportRequestRepository transportRequestRepository;
        private readonly IFestivalDayRepository festivalDayRepository;
        private readonly IParticipantRepository participantRepository;

        public TransportService(ITransportPickupPointRepository transportPickupPointRepository,
            ITransportRequestRepository transportRequestRepository,
            IFestivalDayRepository festivalDayRepository,
            IParticipantRepository participantRepository)
        {
            Check.IsNotNull(transportPickupPointRepository, "transportPickupPointRepository may not be null");
            Check.IsNotNull(transportRequestRepository, "transportRequestRepository may not be null");
            Check.IsNotNull(festivalDayRepository, "festivalDayRepository may not be null");
            Check.IsNotNull(participantRepository, "participantRepository may not be null");

            this.transportPickupPointRepository = transportPickupPointRepository;
            this.transportRequestRepository = transportRequestRepository;
            this.festivalDayRepository = festivalDayRepository;
            this.participantRepository = participantRepository;
        }

        public IList<PickupPointItem> FindPickupPoints()
        {
            return transportPickupPointRepository.FindAll();
        }

        public IList<TransportRequestItem> FindParticipantTransportRequests(Guid participantId)
        {
            return transportRequestRepository.FindParticipantTransportRequests(participantId);
        }

        public IList<FestivalDayItem> FindDaysWithNoTransportRequests(Guid participantId)
        {
            return festivalDayRepository.FindDaysWithNoTransportRequests(participantId);
        }

        public void CreateTransportRequest(TransportRequestModel transportRequestModel)
        {
            Check.IsNotNull(transportRequestModel, "transportRequestModel may not be null");

            transportRequestRepository.Save(new TransportRequest
            {
                Participant =  participantRepository.Load(transportRequestModel.ParticipantId),
                PickupPoint = transportPickupPointRepository.Load(transportRequestModel.TransportPickupPointId),
                PickupDay = festivalDayRepository.Load(transportRequestModel.FestivalDayId)
            });
        }

        public void CancelTransportRequest(Guid transportRequestid)
        {
            var transportRequestToDelete = transportRequestRepository.Get(transportRequestid);

            transportRequestRepository.Delete(transportRequestToDelete);
        }
    }
}
